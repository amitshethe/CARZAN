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
    
    public partial class AdminTable
    {
        public int AdminID { get; set; }
        public Nullable<int> BookingID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string Passwd { get; set; }
        public string MobileNo { get; set; }
        public string AdminAddress { get; set; }
        public string AadharNo { get; set; }
        public string ProfilePic { get; set; }
        public Nullable<System.DateTime> DoB { get; set; }
        public string Gender { get; set; }
    
        public virtual BookingDetail BookingDetail { get; set; }
    }
}
