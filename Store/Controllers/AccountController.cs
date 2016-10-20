using SendGrid.Helpers.Mail;
using Store.Models;
using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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

        // POST: Login
        [HttpPost]
        public ActionResult Login(Login model)
        {
            bool result = WebSecurity.Login(model.username, model.password, false);

            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Register
        [HttpGet]
        public ActionResult Register()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("StoreServer", "Users", "Id", "UserName", autoCreateTables: true);
            }
            return View();
        }

        // POST: Register
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            using (CodingTempleECommerceEntities entities = new CodingTempleECommerceEntities())
            {
                if (!WebSecurity.Initialized)
                {
                    WebSecurity.InitializeDatabaseConnection("StoreServer", "Users", "Id", "UserName", autoCreateTables: true);
                }
                else if (WebSecurity.UserExists(model.username))
                {
                    ModelState.AddModelError("", "Username already exists");
                }
                else
                {

                    string token = WebSecurity.CreateUserAndAccount(model.username, model.password,
                        new {
                            Email = model.email,
                            FirstName = model.firstName,
                            MiddleInitial = model.middleInitial,
                            LastName = model.lastName,
                            StreetName = model.streetName,
                            City = model.city,
                            State = model.state,
                            Zipcode = model.zipcode
                        }, true);


                    string apiKey = ConfigurationManager.AppSettings["SendGrid.Key"];

                    SendGrid.SendGridAPIClient sg = new SendGrid.SendGridAPIClient(apiKey);

                    Email from = new Email("admin@bobsgoods.com");
                    string subject = "Complete your registration";
                    Email to = new Email(model.email);
                    string emailContent = String.Format("<html><body><a href=\"{0}\">Complete your registration</a></body></html>", Request.Url.GetLeftPart(UriPartial.Authority) + "/Account/RegisterConfirmed/" + HttpUtility.UrlEncode(token) + "?userName=" + HttpUtility.UrlEncode(model.username));
                    Content content = new Content("text/html", emailContent);
                    Mail mail = new Mail(from, subject, to, content);

                    sg.client.mail.send.post(requestBody: mail.Get());

                    return RedirectToAction("RegisterComplete");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            WebSecurity.Logout();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult RegisterComplete()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult RegisterConfirmed(string id, string userName)
        {
            if (WebSecurity.ConfirmAccount(userName, id))
            {

                ViewBag.Confirmed = true;
            }
            else
            {
                ViewBag.Confirmed = false;
            }
            return View();
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            if (WebSecurity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            string username = WebSecurity.CurrentUserName;

            if(model.newPassword != model.confirmNewPassword)
            {
                ModelState.AddModelError("", "Passwords do not match");
            }
            else if (WebSecurity.IsAuthenticated)
            {
                bool result = WebSecurity.ChangePassword(username, model.currentPassword, model.newPassword);

                if (result)
                {
                    Logout();
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Password was not changed");
                }
            }
            return View();
        }
    }
}