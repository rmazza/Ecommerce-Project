﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class CheckoutModel
    {
        public string username { get; set; }
        public int userID { get; set; }
        public int cartID { get; set; }

        [DisplayName("First Name:")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(20, MinimumLength = 2)]
        public string firstName { get; set; }

        [DisplayName("Middle Initial:")]
        public string middleInitial { get; set; }

        [DisplayName("Last Name:")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(20, MinimumLength = 2)]
        public string lastName { get; set; }

        [DisplayName("Street:")]
        [Required(ErrorMessage = "Street Address is required")]
        [StringLength(40)]
        public string streetName { get; set; }

        [DisplayName("City:")]
        [Required(ErrorMessage = "City is required")]
        [StringLength(20, MinimumLength = 2)]
        public string city { get; set; }

        [DisplayName("State:")]
        [Required(ErrorMessage = "State is required")]
        [StringLength(2, MinimumLength = 2)]
        public string state { get; set; }

        [DisplayName("Zipcode:")]
        [Required(ErrorMessage = "Zipcode is required")]
        public Nullable<int> zipcode { get; set; }

    }
}