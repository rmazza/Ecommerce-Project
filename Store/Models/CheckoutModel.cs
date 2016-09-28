using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class CheckoutModel
    {
        [DisplayName("First Name:")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(20, MinimumLength = 2)]
        public string firstName { get; set; }

        [DisplayName("Last Name:")]
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string lastName { get; set; }

        [DisplayName("Email:")]
        [Required]
        [EmailAddress]
        [StringLength(30)]
        public string email { get; set; }

        [DisplayName("Street:")]
        [Required]
        [StringLength(40)]
        public string streetName { get; set; }

        [DisplayName("City:")]
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string city { get; set; }

        [DisplayName("State:")]
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string state { get; set; }

        [DisplayName("Zipcode:")]
        [Required]
        [StringLength(5, MinimumLength = 5)]
        public string zipcode { get; set; }

    }
}