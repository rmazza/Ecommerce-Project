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
    
    public partial class SalesOrderHeader
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string SessionKey { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalTaxes { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
        public int SalesOrderID { get; set; }
    
        public virtual User User { get; set; }
    }
}