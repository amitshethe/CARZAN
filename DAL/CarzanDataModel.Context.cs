﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarzanEntities : DbContext
    {
        public CarzanEntities()
            : base("name=CarzanEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BookingDetail> BookingDetails { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<AdminTable> AdminTables { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
    }
}
