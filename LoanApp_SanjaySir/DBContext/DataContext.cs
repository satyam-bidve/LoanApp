using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Web;
using LoanApp_SanjaySir.DbModels;
using LoanApp_SanjaySir.Models;

namespace LoanApp_SanjaySir.DBContext
{
    public class DataContext : DbContext
    {
        public DataContext(string connectionString) : base(connectionString) { }

       // public virtual DbSet<Constomer> Constomers { get; set; }

      //  public virtual DbSet<Loan> Loans{ get; set; }

        public virtual DbSet<CustomerDetails> Constomers { get; set; }

        public virtual DbSet<LoanDetails> Loans { get; set; }

        public virtual DbSet<RegisterCustomer> CustomersLog { get; set; }

    }
}