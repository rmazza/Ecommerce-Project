using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class ProductModel
    {
        public string modelNumber { get; set; }
        public int? ID { get; set; }
        public string productName { get; set; }
        public string productBrand { get; set; }
        public string productDescription { get; set; }
        public string sport { get; set; }
        public decimal? productPrice { get; set; }
        public bool inStock { get; set; }
        public int? size { get; set; }
        public string position { get; set; }
        public ImageModel[] images { get; set; }
    }
}