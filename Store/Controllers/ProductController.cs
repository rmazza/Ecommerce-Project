using Store.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace Store.Controllers
{
    [Log]
    public class ProductController : Controller
    {
        public ActionResult Products()
        {
            List<ProductModel> model = new List<ProductModel>();

            using (CodingTempleECommerceEntities entities = new CodingTempleECommerceEntities())
            {
                model = entities.Products.Select(x => new ProductModel
                {
                    ID = x.Id,
                    inStock = x.InStock ?? false,
                    modelNumber = x.ModelNumber,
                    position = x.Position,
                    productBrand = x.ProductBrand,
                    productDescription = x.ProductDescription,
                    productName = x.ProductName,
                    productPrice = x.ProductPrice,
                    size = x.Size,
                    sport = x.Sport,
                    images = x.Images.Select(y => new ImageModel
                    {
                        img = y.ImgLink
                    })
                }).ToList();
            }
            return View(model);
        }

        public ActionResult SingleProduct(int? id)
        {
            if (id == null) { id = 1; }

            using (CodingTempleECommerceEntities entities = new CodingTempleECommerceEntities())
            {
                var prod = entities.Products.Single(x => x.Id == id);
               
                ProductModel model = new ProductModel();

                model.ID = prod.Id;
                model.productBrand = prod.ProductBrand;
                model.productName = prod.ProductName;
                model.productPrice = prod.ProductPrice;
                model.productDescription = prod.ProductDescription;
                model.size = prod.Size;
                model.sport = prod.Sport;
                model.modelNumber = prod.ModelNumber;
                model.inStock = (bool)prod.InStock;
                model.position = prod.Position;
                model.images = entities.Images.Where(x => x.ProductId == id).Select(x => new ImageModel { img = x.ImgLink }).ToList();

            return View(model);
            }
        }


        [HttpPost]
        public ActionResult SingleProduct(ProductModel model, int? quantity)
        {

            //To Do: Add product to cart in database
            return View(model);

        }

            //if (Request.Cookies["OrderHeader"] == null)
            //{
            //    //Execute normally by adding new cart
            //}else
            //{
            //    //Fetch cookie
            //    //header = entities.salesOrderHeader.Single(x => x.SalesOrderID == int.Parse(Request.Cookies["OrderHeader"].Value));
            //}


            //Response.Cookies.Add(new System.Web.HttpCookie("Order Header", header.salesorderid.tostring(())))
                //return RedirectToAction("Index", "Home");
                // redirect to index of the homeContoller
                //return RedirectToAction("Index", "Checkout");
            
        }

    }
