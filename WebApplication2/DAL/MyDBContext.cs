using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebApplication2.Models;

namespace WebApplication2.DAL
{
    public class MyDBContext : DbContext
    {
       
            public MyDBContext() : base("MyDBContext")
            {

            }
            public DbSet<Customer> Customers { get; set; } // My domain model
            public DbSet<Movie> Movies { get; set; }// My domain models      
            public DbSet<MembershipType> MembershipTypes { get; set; }
            public DbSet<GenreType> GenreTypes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
    }
}
    