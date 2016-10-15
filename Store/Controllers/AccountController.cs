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
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
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
        public ActionResult Register(Register model)
        {
            using (CodingTempleECommerceEntities entities = new CodingTempleECommerceEntities())
            {
                string n = model.usr.Username;
                bool alreadyExistes = entities.Users.Any(x => x.Username == n);

                if (!alreadyExistes)
                {
                    WebSecurity.CreateUserAndAccount(model.usr.Username, model.password);
                    WebSecurity.Login(model.usr.Username, model.password);

                    ViewBag.Message = "Successfully Logged In";
                    RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Username already Exists");
                }
            }
            return View();
        }
    }
}