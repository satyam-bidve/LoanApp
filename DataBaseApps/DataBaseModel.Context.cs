﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBaseApps
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LoanAppDataBaseEntities : DbContext
    {
        public LoanAppDataBaseEntities()
            : base("name=LoanAppDataBaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CustomerInfo> CustomerInfo { get; set; }
        public virtual DbSet<DocumentDetails> DocumentDetails { get; set; }
        public virtual DbSet<LoanDetails> LoanDetails { get; set; }
    }
}
