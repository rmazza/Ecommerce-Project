using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "First Name is required")]
        public string firstName { get; set; }

        public string lastName { get; set; }

        [Required(ErrorMessage = "Please enter a message")]
        public string message { get; set; }
    }
}