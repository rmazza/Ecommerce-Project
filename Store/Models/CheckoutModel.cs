using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class CheckoutModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string streetName { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }

    }
}