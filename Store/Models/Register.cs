using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class Register
    {
        public User usr { get; set; }
        public Customer cust { get; set; }
        public CustomerAddress custAdd { get; set; }
        public string password { get; set; }
    }
}