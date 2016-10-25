using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class RecieptModel
    {
        public CheckoutModel checkModel { get; set; }
        public IEnumerable<Cart> currentCart { get; set; }
        public SalesOrder sale { get; set; }
    }
}