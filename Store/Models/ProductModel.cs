using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string productName { get; set; }
        public decimal? productPrice { get; set; }
        public int? quantity { get; set; }
    }
}