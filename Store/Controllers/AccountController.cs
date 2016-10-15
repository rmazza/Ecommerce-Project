using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Store.Controllers
{
    public class AccountController : Controller
    {
        // GET: Index
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login
        public ActionResult Login()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("StoreServer", "Users", "Id", "UserName", autoCreateTables: true);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login model)
        {
            bool success = WebSecurity.Login(model.username, model.password, false);
            if (success)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("StoreServer", "Users", "Id", "UserName", autoCreateTables: true);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            using (CodingTempleECommerceEntities entities = new CodingTempleECommerceEntities())
            {
                bool alreadyExistes = entities.Users.Any(x => x.Username == model.username);
           
                if (!alreadyExistes)
                {
                    WebSecurity.CreateUserAndAccount(model.username, model.password);
                    WebSecurity.Login(model.username, model.password);

                    ViewBag.Message = "Successfully Logged In";
                    return RedirectToAction("");
                }
                else
                {
                    ModelState.AddModelError("", "Username already Exists");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
                Session.Clear();
                Session.Abandon();

                WebSecurity.Logout();
                return RedirectToAction("Login");

        }
    }
}