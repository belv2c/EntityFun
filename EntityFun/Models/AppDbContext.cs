using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EntityFun.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("EntityFun") {}

        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
    }
}