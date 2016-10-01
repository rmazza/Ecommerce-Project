using Store.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Store.Controllers
{
    [Log]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {

                return View();

        }

        [HttpPost]
        public ActionResult Index(ProductModel model)
        {

            //To Do: Add product to cart in database


            //return RedirectToAction("Index", "Home");
            // redirect to index of the homeContoller
            return RedirectToAction("Index", "Checkout");
            
        }

    }
}