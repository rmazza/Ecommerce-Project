using SendGrid.Helpers.Mail;
using Store.Models;
using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace Store.Controllers
{
    public class AccountController : Controller
    {
        private string passResetToken { get; set; }

        // GET: Index
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login
        [HttpGet]
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
            else
            {
                ModelState.AddModelError("", "Username or Password is incorrect");
            }

            return View();
        }

        // GET: Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            using (CodingTempleECommerceEntities entities = new CodingTempleECommerceEntities())
            {
                if (model.password != model.confirmPassword)
                {
                    ModelState.AddModelError("", "Passwords do not match");
                }
                else if (WebSecurity.UserExists(model.username))
                {
                    ModelState.AddModelError("", "Username already exists");
                }
                else
                {
                    string token = WebSecurity.CreateUserAndAccount(model.username, model.password,
                        new {
                            Email = model.email
                        }, true);


                    string apiKey = ConfigurationManager.AppSettings["SendGrid.Key"];

                    SendGrid.SendGridAPIClient sg = new SendGrid.SendGridAPIClient(apiKey);

                    Email from = new Email("CustomerSupport@bobsgoods.com");
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

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordModel model)
        {
            if (WebSecurity.UserExists(model.nameOrEmail))
            {
                using (CodingTempleECommerceEntities db = new CodingTempleECommerceEntities())
                {
                    var usr = db.Users.Where(x => x.Username == model.nameOrEmail).SingleOrDefault();

                    string token = WebSecurity.GeneratePasswordResetToken(model.nameOrEmail, 60);

                    string apiKey = ConfigurationManager.AppSettings["SendGrid.Key"];
                    SendGrid.SendGridAPIClient sg = new SendGrid.SendGridAPIClient(apiKey);

                    Email from = new Email("CustomerSupport@bobsgoods.com");
                    string subject = "Complete your registration";
                    Email to = new Email(usr.Email);
                    string emailContent = String.Format("<html><body><a href=\"{0}\">Click to Here to reset your password</a></body></html>", Request.Url.GetLeftPart(UriPartial.Authority) + "/Account/ResetPassword/" + HttpUtility.UrlEncode(token) + "?userName=" + HttpUtility.UrlEncode(model.nameOrEmail));
                    Content content = new Content("text/html", emailContent);
                    Mail mail = new Mail(from, subject, to, content);

                    sg.client.mail.send.post(requestBody: mail.Get());
                }
            }
            else
            {
                ModelState.AddModelError("", "User does not exist in the database");
            }
            return RedirectToAction("ResetComplete");
        }

        [HttpGet]
        public ActionResult ResetComplete()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ResetPassword(string id, string userName)
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(string id, string newPass,string confirmPass)
        {
            if(newPass != confirmPass)
            {
                ModelState.AddModelError("", "Passwords do not match");
            }else
            {
                bool result = WebSecurity.ResetPassword(id, newPass);

                if (result)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Password reset failed, please try again");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult ContactAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactAdmin(ContactModel model)
        {
            using (CodingTempleECommerceEntities db = new CodingTempleECommerceEntities())
            {
                string email = db.Users.Single(x => x.Username == "admin").Email;

                string apiKey = ConfigurationManager.AppSettings["SendGrid.Key"];
                SendGrid.SendGridAPIClient sg = new SendGrid.SendGridAPIClient(apiKey);

                Email from = new Email("Contact@bob.com");
                string subject = String.Format("New customer message from {0}",model.firstName);
                Email to = new Email(email);
                string emailContent = String.Format("<html><body>{0}</body></html>",model.message);
                Content content = new Content("text/html", emailContent);
                Mail mail = new Mail(from, subject, to, content);

                sg.client.mail.send.post(requestBody: mail.Get());
                return RedirectToAction("ContactComplete");
            }
        }

        [HttpGet]
        public ActionResult ContactComplete()
        {
            return View();
        }
    }
}