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

        [Required(ErrorMessage = "Confirm Password is required")]
        public string confirmPassword { get; set; }

        [DisplayName("Email:")]
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        [StringLength(120)]
        public string email { get; set; }

    }
}