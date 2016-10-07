using Store.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Store
{
    public class ValuesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<ProductModel> Get()
        {
            return new ProductModel[] {
                new ProductModel {
                    ID = 1,
                    productName = "RAWLINGS RGGNP5",
                    productPrice = 499.99m,
                    productDescription = "The culmination of 100 years of Rawlings' glove-making craftsmanship, the new Rawlings Gold Glove series with Opti-Core™ Technology delivers the ultimate in playability and feel, inspiring a new generation of defensive excellence. These gloves feature flawless, European leather famous for its supple feel and durable finish combined with special features like hand-sewn welting and ultra-premium, luxury palm lining comfortably completes a fit and feel that can only be described as custom. These gloves are meticulously cut, assembled and sewn, start to finish, by a single craftsman, all Rawlings Gold Gloves carry an individual serial number signifying the maker, the date created and the glove's production number.",
                    modelNumber = "RGGNP5",
                    sport = "Baseball",
                    category = "Baseball Gloves",
                    size = "11.75",
                    position = "Infield",
                    inStock = 1,
                    images = new ImageModel[]
                        {
                            new ImageModel { img = "/Images/BaseballGloves/Rawlings_RGGNP5/1.jpg" },
                            new ImageModel { img = "/Images/BaseballGloves/Rawlings_RGGNP5/2.jpg" },
                            new ImageModel { img = "/Images/BaseballGloves/Rawlings_RGGNP5/3.jpg" },
                            new ImageModel { img = "/Images/BaseballGloves/Rawlings_RGGNP5/4.jpg" },
                            new ImageModel { img = "/Images/BaseballGloves/Rawlings_RGGNP5/5.jpg" }
                        }
                },
                new ProductModel {
                    ID = 2,
                    productName = "NOKONA P4",
                    productPrice = 449.99m,
                    productDescription = "Bloodline™ is back – and better than ever. A pro model glove that is highly structured and extremely lightweight. Made with Nokona’s proprietary Kangaroo leather: one of the strongest, most durable leathers in the world, yet still very light weight. Bloodline™ is re-engineered with a new interior padding system that provides superior structure, and still allows for great feel and ball control.",
                    modelNumber = "P4",
                    sport = "Baseball",
                    category = "Baseball Gloves",
                    size = "11.25",
                    position = "Infield",
                    inStock = 1,
                    images = new ImageModel[]
                        {
                            new ImageModel { img = "/Images/BaseballGloves/Nokona_P4/1.jpg" },
                            new ImageModel { img = "/Images/BaseballGloves/Nokona_P4/2.jpg" },
                            new ImageModel { img = "/Images/BaseballGloves/Nokona_P4/3.jpg" },
                            new ImageModel { img = "/Images/BaseballGloves/Nokona_P4/4.jpg" },
                            new ImageModel { img = "/Images/BaseballGloves/Nokona_P4/5.jpg" }
                        }
                },
                new ProductModel {
                    ID = 3,
                    productName = "NOKONA P2",
                    productPrice = 449.99m,
                    productDescription = "Bloodline™ is back – and better than ever. A pro model glove that is highly structured and extremely lightweight. Made with Nokona’s proprietary Kangaroo leather: one of the strongest, most durable leathers in the world, yet still very light weight. Bloodline™ is re-engineered with a new interior padding system that provides superior structure, and still allows for great feel and ball control.",
                    modelNumber = "P2",
                    sport = "Baseball",
                    category = "Baseball Gloves",
                    size = "33",
                    position = "Catcher",
                    inStock = 1,
                    images = new ImageModel[]
                        {
                            new ImageModel { img = "/Images/BaseballGloves/Nokona_P2/1.jpg" },
                            new ImageModel { img = "/Images/BaseballGloves/Nokona_P2/2.jpg" },
                            new ImageModel { img = "/Images/BaseballGloves/Nokona_P2/3.jpg" },
                            new ImageModel { img = "/Images/BaseballGloves/Nokona_P2/4.jpg" },
                            new ImageModel { img = "/Images/BaseballGloves/Nokona_P2/5.jpg" }
                        }
                },
                new ProductModel {
                    ID = 4,
                    productName = "NOKONA P5",
                    productPrice = 449.99m,
                    productDescription = "Bloodline™ is back – and better than ever. A pro model glove that is highly structured and extremely lightweight. Made with Nokona’s proprietary Kangaroo leather: one of the strongest, most durable leathers in the world, yet still very light weight. Bloodline™ is re-engineered with a new interior padding system that provides superior structure, and still allows for great feel and ball control.",
                    modelNumber = "P5",
                    sport = "Baseball",
                    category = "Baseball Gloves",
                    size = "11.78",
                    position = "Infield",
                    inStock = 1,
                    images = new ImageModel[]
                        {
                            new ImageModel { img = "/Images/BaseballGloves/Nokona_P5/1.jpg" },
                            new ImageModel { img = "/Images/BaseballGloves/Nokona_P5/2.jpg" },
                            new ImageModel { img = "/Images/BaseballGloves/Nokona_P5/3.jpg" },
                            new ImageModel { img = "/Images/BaseballGloves/Nokona_P5/4.jpg" },
                            new ImageModel { img = "/Images/BaseballGloves/Nokona_P5/5.jpg" }
                        }
                },
               new ProductModel {
                    ID = 5,
                    productName = "UNDER ARMOUR UACM-PRO1 PRO SERIES",
                    productPrice = 379.99m,
                    productDescription = "Wagyu cattle are known for their high quality and demand some of the highest leather prices. The hide is soft to touch but firm and durable, qualities which make a standout professional mitt.  The glove's pattern features a wide and deep pocket. Thick heel and toe padding ensure balls received don't pop out. PTH padding in the base of the hand helps prevent sting and extends the life of the mitt.  Vertical laces between the web and pocket of the mitt make the mitt much stronger and reduce chances of a snapped lace or torn web.",
                    modelNumber = "UACM-PRO1",
                    sport = "Baseball",
                    category = "Baseball Gloves",
                    size = "34",
                    position = "Catcher",
                    inStock = 1,
                    images = new ImageModel[]
                        {
                            new ImageModel { img = "/Images/BaseballGloves/Under_Armour_UACM-PRO1/1.jpg" },
                            new ImageModel { img = "/Images/BaseballGloves/Under_Armour_UACM-PRO1/2.jpg" },
                            new ImageModel { img = "/Images/BaseballGloves/Under_Armour_UACM-PRO1/3.jpg" },
                            new ImageModel { img = "/Images/BaseballGloves/Under_Armour_UACM-PRO1/4.jpg" },
                            new ImageModel { img = "/Images/BaseballGloves/Under_Armour_UACM-PRO1/5.jpg" }
                        }
                }

            };
        }

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