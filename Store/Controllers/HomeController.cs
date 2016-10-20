using SendGrid.Helpers.Mail;
using Store.Models;
using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using System.Linq;
using System.Collections.Generic;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("StoreServer", "Users", "Id", "UserName", autoCreateTables: true);
            }
         
            using (CodingTempleECommerceEntities db = new CodingTempleECommerceEntities())
            {
                //var images = db.Images.Where(x => x.Id % 5 == 0).Select(x => new ImageModel { img = x.ImgLink }).ToList();
                var images = db.Images.Where(x => x.Id % 5 == 0).Select(x => new ImageModel { img = x.ImgLink, prodID = x.ProductId }).ToList();

                return View(images);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Sample = "Sample text";

            return View();
        }
    }
}