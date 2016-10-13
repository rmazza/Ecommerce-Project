using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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

                    bool userValid = entities.Users.Any(x => x.Username == username && x.Password == password);

                    if (userValid)
                    {
                        FormsAuthentication.SetAuthCookie(username, false);
                    }
                }

            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register()
        {
            if (ModelState.IsValid)
            {
                using (CodingTempleECommerceEntities entities = new CodingTempleECommerceEntities())
                {
                    int newID = entities.Users.Max(x => x.Id) + 1;
                }
            }
            return View();
        }
    }
}