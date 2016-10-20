using Store.Models;
using System.Web.Mvc;
using System.Linq;
using System;
using WebMatrix.WebData;
using System.Configuration;
using System.Net;
using System.Web;
using System.IO;
using Newtonsoft.Json.Linq;
using Rentler.SmartyStreets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Controllers
{
    [Log]
    public class CheckoutController : Controller
    {
        int numItems { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CheckoutModel model)
        { 
            if (ModelState.IsValid)
            {
                //TODO: Save Checkout info to database
                using (CodingTempleECommerceEntities entitites = new CodingTempleECommerceEntities())
                {
                }
                    return RedirectToAction("Index", "Receipt");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult AddToCart()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddToCart(int id, int qty, decimal? price)
        {
            bool idAlreadyTaken = true;
            Guid tempCartId;

            using (CodingTempleECommerceEntities db = new CodingTempleECommerceEntities())
            {
                if (Session["SessionKey"] == null)
                {
                    while (idAlreadyTaken)
                    {
                        tempCartId = Guid.NewGuid();
                        idAlreadyTaken = db.Carts.Any(x => x.SessionKey == tempCartId.ToString());
                        Session["SessionKey"] = tempCartId.ToString();
                    }   
                }
                
                string sesKey = Session["SessionKey"].ToString();

                var cartItem = db.Carts.SingleOrDefault(x => x.SessionKey == sesKey && x.ProductID == id);

                if(cartItem == null)
                {
                    var newitem = new Cart
                    {
                        SessionKey = sesKey,
                        Qty = (int)qty,
                        DateCreated = DateTime.Now,
                        ProductID = id,
                        UserID = WebSecurity.CurrentUserId,
                        ProductPrice = price
                    };

                    db.Carts.Add(newitem);
                }
                else
                {
                   cartItem.Qty += qty;
                }
                db.SaveChanges();
            }           
            return RedirectToAction("Products", "Product");
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            return View();
        }

        public async Task<ActionResult> Checkout(CheckoutModel model)
        {
            var result = await VerifyAddress(model.streetName, model.city, model.state, model.zipcode);
            return View();
        }

        public async Task<List<SmartyStreetsAddress>> VerifyAddress(string streetName, string cityName, string stateName, int? zipCode)
        {
            string authId = ConfigurationManager.AppSettings["SmartyStreets.AuthID"];
            string authToken = ConfigurationManager.AppSettings["SmartyStreets.AuthToken"];

            var client = new SmartyStreetsClient(
                    authId: authId,
                    authToken: authToken);

            var results = new List<SmartyStreetsAddress>();
            
            results.AddRange(
              (await client.GetStreetAddressAsync(
                street: streetName,
                city: cityName,
                state: stateName,
                zipcode: zipCode.ToString())));

            return results;
        }
    }
}