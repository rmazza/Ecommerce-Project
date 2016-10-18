using Store.Models;
using System.Web.Mvc;
using System.Linq;
using System;
using WebMatrix.WebData;

namespace Store.Controllers
{
    [Log]
    public class CheckoutController : Controller
    {

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
        public ActionResult AddToCart(ProductModel model, int qty)
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

                var cartItem = db.Carts.SingleOrDefault(x => x.SessionKey == sesKey && x.ProductID == model.ID);

                if(cartItem == null)
                {
                    var newitem = new Cart
                    {
                        SessionKey = sesKey,
                        Qty = (int)qty,
                        DateCreated = DateTime.Now,
                        ProductID = (int)model.ID,
                        UserID = WebSecurity.CurrentUserId
                    };
                    db.Carts.Add(newitem);
                }
                else
                {
                   cartItem.Qty += qty;
                }
                db.SaveChanges();
            }           
            return RedirectToRoute("~/Product/Products");
        }
    }
}