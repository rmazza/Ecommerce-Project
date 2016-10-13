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
                using (CodingTempleECommerceEntities entitites = new CodingTempleECommerceEntities())
                {
                    entitites.Customers.Add(
                        new Customer {
                            FirstName = model.firstName,
                            LastName = model.lastName,
                            Email = model.email,
                           
                        });

                    entitites.CustomerAddresses.Add(
                        new CustomerAddress
                        {
                            City = model.city,
                            StateProvince = model.state,
                            StreetName = model.streetName,
                            ZipCode = model.zipcode,
                      
                        });
                }
                    return RedirectToAction("Index", "Receipt");
            }
            else
            {
                return View(model);
            }
        }
    }
}