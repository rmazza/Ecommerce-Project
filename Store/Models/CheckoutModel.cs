using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class CheckoutModel
    {
        [DisplayName("First Name:")]
        public string firstName { get; set; }

        [DisplayName("Last Name:")]
        public string lastName { get; set; }

        [DisplayName("Street:")]
        public string streetName { get; set; }

        [DisplayName("City:")]
        public string city { get; set; }

        [DisplayName("State:")]
        public string state { get; set; }

        [DisplayName("Zipcode:")]
        public string zipcode { get; set; }

    }
}