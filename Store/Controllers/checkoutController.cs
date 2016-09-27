using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class CheckoutController : Controller
    {

        public ActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Index(CheckoutModel model)
        {
            return Json(new
            {
                
            });
        }
    }
}