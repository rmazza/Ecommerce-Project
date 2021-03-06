//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Store.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalesOrder
    {
        public int Id { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerMiddleInitial { get; set; }
        public string CustomerLastName { get; set; }
        public string SessionKey { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public int UserID { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Taxes { get; set; }
        public decimal Total { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual User User { get; set; }
    }
}
