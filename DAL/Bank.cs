//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bank
    {
        public int AccountNo { get; set; }
        public Nullable<int> UserID { get; set; }
        public string CardNo { get; set; }
        public string Expiry { get; set; }
        public string CVV { get; set; }
        public Nullable<int> Balance { get; set; }
    
        public virtual User User { get; set; }
    }
}
