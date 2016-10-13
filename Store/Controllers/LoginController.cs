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
                    var usr = entities.Users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

                    if(usr != null)
                    {
                        Session["UserID"] = usr.Id.ToString();
                        Session["Username"] = usr.Username.ToString();
                        return RedirectToAction();
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Register()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (CodingTempleECommerceEntities entities = new CodingTempleECommerceEntities())
        //        {
        //            int newID = entities.Users.Max(x => x.Id) + 1;
        //        }
        //    }
        //    return View();
        //}
    }
}