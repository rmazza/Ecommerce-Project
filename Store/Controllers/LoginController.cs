using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User model, string returnURL) {
            if (ModelState.IsValid)
            {
                using (CodingTempleECommerceEntities entities = new CodingTempleECommerceEntities())
                {
                    string username = model.Username;
                    string password = model.Password;
                }

            }

            return View(model);
        }
    }
}