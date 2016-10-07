using Store.Models;
using System.Web.Mvc;


namespace Store.Controllers
{
    [Log]
    public class CheckoutController : Controller
    {

        public ActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Index(CheckoutModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO: Save Checkout info to database
                return RedirectToAction("Index", "Receipt");
            }else
            {
                return View(model);
            }
        }
    }
}