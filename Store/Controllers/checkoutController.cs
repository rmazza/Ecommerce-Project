﻿using Store.Models;
using System.Web.Mvc;
using System.Linq;
using System;
using WebMatrix.WebData;
using System.Configuration;
using Rentler.SmartyStreets;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Store.Controllers
{
    [Log]
    public class CheckoutController : Controller
    {
        private decimal Tax_1 = 0;
        private decimal Tax_2 = 0;
        private decimal Tax_3 = 0;

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
            int identification = 0;

            identification = (WebSecurity.IsAuthenticated) ? WebSecurity.CurrentUserId : 0;

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
                        UserID = identification,
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

        [HttpPost]
        public async Task<ActionResult> Checkout(CheckoutModel model)
        {
            var result = await VerifyAddress(model.streetName, model.city, model.state, model.zipcode);

            if(result.Count == 0)
            {
                ModelState.AddModelError("", "Invalid Address Given");
            }
            else
            {
                RecieptModel recModel = new RecieptModel();

                var sesKey = Session["Sessionkey"].ToString();
                decimal subTotal = 0;

                using (CodingTempleECommerceEntities db = new CodingTempleECommerceEntities())
                {
                    var carts = db.Carts.Where(c => c.SessionKey == sesKey).Include(c => c.Product).Include(c => c.User).ToList();

                    foreach (var item in carts)
                    {
                        subTotal += (decimal)item.ProductPrice * item.Qty;
                    }

                    var order = new SalesOrder
                    {
                        CustomerFirstName = model.firstName,
                        CustomerMiddleInitial = model.middleInitial,
                        CustomerLastName = model.lastName,
                        SessionKey = sesKey,
                        Address = model.streetName,
                        City = model.city,
                        State = model.state,
                        Zipcode = (int)model.zipcode,
                        UserID = WebSecurity.CurrentUserId,
                        SubTotal = subTotal,
                        Total = subTotal + Tax_1 + Tax_2 + Tax_3,
                        Date = DateTime.Now
                    };

                    db.SalesOrders.Add(order);
                    db.SaveChanges();

                    recModel.currentCart = carts;
                    recModel.sale = order;
                    recModel.checkModel = model;

                    Session["SessionKey"] = null;
                    return View(recModel);
                }
            }
           

            return RedirectToAction("Index");
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