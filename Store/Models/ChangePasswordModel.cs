using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Current Password is required")]
        [StringLength(40, MinimumLength = 2)]
        public string currentPassword { get; set; }

        [Required(ErrorMessage = "New Password is required")]
        [StringLength(40, MinimumLength = 2)]
        public string newPassword { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(40, MinimumLength = 2)]
        public string confirmNewPassword { get; set; }

    }
}
