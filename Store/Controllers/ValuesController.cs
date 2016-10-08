using Store.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace Store
{
    public class ValuesController : ApiController
    {

        // GET api/<controller>
        public IEnumerable<ProductModel> Get()
        {
            List<ProductModel> model = new List<ProductModel>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["StoreServer"].ConnectionString))
            {

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "sp_GetAllProducts";
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProductModel pm = new ProductModel();

                        pm.ID = reader.GetInt32(reader.GetOrdinal("Id"));
                        pm.productName = reader.GetString(reader.GetOrdinal("ProductName"));
                        pm.productPrice = reader.GetDecimal(reader.GetOrdinal("ProductPrice"));
                        pm.productDescription = reader.GetString(reader.GetOrdinal("ProductDescription"));
                        pm.modelNumber = reader.GetString(reader.GetOrdinal("ModelNumber"));
                        pm.size = reader.GetInt32(reader.GetOrdinal("Size"));
                        pm.position = reader.GetString(reader.GetOrdinal("Position"));
                        pm.inStock = reader.GetBoolean(reader.GetOrdinal("InStock"));
                        pm.sport = reader.GetString(reader.GetOrdinal("Sport"));
                        pm.productBrand = reader.GetString(reader.GetOrdinal("ProductBrand"));

                        model.Add(pm);
                    }
                }

                cmd.CommandText = "sp_GetProductImages";
                cmd.CommandType = CommandType.StoredProcedure;

                foreach(ProductModel m in model)
                {
                    List<ImageModel> imgModel = new List<ImageModel>();

                    cmd.Parameters.AddWithValue("@prodName", m.productName);

                    using(SqlDataReader imgReader = cmd.ExecuteReader())
                    {
                        while (imgReader.Read())
                        {
                            imgModel.Add(new ImageModel
                            {
                                img = imgReader.GetString(imgReader.GetOrdinal("ImgLink"))
                            });
                        }
                    }
                    cmd.Parameters.Clear();
                    m.images = imgModel.ToArray();
                }
                //cmd.Parameters.AddWithValue("@prodName",)

            }

            return model;
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