using Store.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Store.Controllers
{
    [Log]
    public class ListController : Controller
    {
        // GET: list
        public ActionResult Index()
        {
            return View();
        }

        // GET: list
        public ActionResult Data()
        {
            List<ProductModel> model = new List<ProductModel>();
            model.Add(new ProductModel { ID = 1, productName = "product1", productPrice = 10.00m });
            model.Add(new ProductModel { ID = 2, productName = "product2", productPrice = 12.95m });
            model.Add(new ProductModel { ID = 3, productName = "product3", productPrice = 14.95m });
            model.Add(new ProductModel { ID = 4, productName = "product4", productPrice = 16.95m });
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}