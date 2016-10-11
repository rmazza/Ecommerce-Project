using Store.Models;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using System.Linq;

namespace Store
{
    public class ValuesController : ApiController
    {

        //// GET api/<controller>
        //public IEnumerable<ProductModel> Get()
        //{
        //    using (CodingTempleECommerceEntities entities = new CodingTempleECommerceEntities())
        //    {
        //        //return entities.Products.Select(x => new ProductModel
        //        //{
        //        //    ID = x.Id,
        //        //    inStock = x.InStock ?? false,
        //        //    modelNumber = x.ModelNumber,
        //        //    position = x.Position,
        //        //    productBrand = x.ProductBrand,
        //        //    productDescription = x.ProductDescription,
        //        //    productName = x.ProductName,
        //        //    productPrice = x.ProductPrice,
        //        //    size = x.Size,
        //        //    sport = x.Sport,
        //        //    images = x.Images.Select(y => new ImageModel
        //        //    {
        //        //        img = y.ImgLink
        //        //    })
        //        //}).ToList();
        //    }
            
        
        //}

        // GET api/<controller>/5
        public string Get(int id)
        {
            return null;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}