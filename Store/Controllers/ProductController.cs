using Store.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Store.Controllers
{
    [Log]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int? id)
        {
            if (id >= 1)
            {
                return View();
            }
            else
            {
                return new HttpNotFoundResult("Product Not Found");
            }
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