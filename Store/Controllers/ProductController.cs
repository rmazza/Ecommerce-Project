using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    [Log]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int? id)
        {
            if (id == 1)
            {
                return View(new ProductModel { ID = 1, productName = "product1", productPrice = 10.00m });
            }
            else if(id == 2)
            {
                return View(new ProductModel { ID = 1, productName = "product2", productPrice = 12.95m });
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