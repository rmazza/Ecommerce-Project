using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        public string nameOrEmail { get; set; }
    }
}