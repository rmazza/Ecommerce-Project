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
        public ActionResult Index(User model)
        {
                using (CodingTempleECommerceEntities entities = new CodingTempleECommerceEntities())
                {
                    var usr = entities.Users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

                    if (usr != null)
                    {
                        Session["UserID"] = usr.Id.ToString();
                        Session["Username"] = usr.Username.ToString();
                        return RedirectToAction("LoggedIn");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username or Password is incorrect.");
                    }

                }
                return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            if(Session["UserID"] != null)
            {
                Session.Clear();
            }
            return RedirectToAction("Index");
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