using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class RegisterModel
    {
        [DisplayName("User Name:")]
        [Required(ErrorMessage = "User Name is required")]
        public string username { get; set; }

        [DisplayName("Password:")]
        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }

        [DisplayName("Email:")]
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        [StringLength(120)]
        public string email { get; set; }

        [DisplayName("First Name: (Optional)")]
        [StringLength(20, MinimumLength = 2)]
        public string firstName { get; set; }

        [DisplayName("Middle Initial: (Optional)")]
        public string middleInitial { get; set; }

        [DisplayName("Last Name: (Optional)")]
        [StringLength(20, MinimumLength = 2)]
        public string lastName { get; set; }

        [DisplayName("Street: (Optional)")]
        [StringLength(40)]
        public string streetName { get; set; }

        [DisplayName("City: (Optional)")]
        [StringLength(20, MinimumLength = 2)]
        public string city { get; set; }

        [DisplayName("State: (Optional)")]
        [StringLength(2, MinimumLength = 2)]
        public string state { get; set; }

        [DisplayName("Zipcode: (Optional)")]
        [StringLength(5, MinimumLength = 5)]
        public Nullable<int> zipcode { get; set; }
    }
}