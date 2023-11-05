using NetFlixPrac.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NetFlixPrac.EF
{
    public class MyContext : DbContext
    {
        public MyContext() : base("Ali") 
        {

        }

        public DbSet<Customer>  Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }

    }
}