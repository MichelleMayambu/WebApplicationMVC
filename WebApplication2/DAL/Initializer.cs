using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication2.Models;
using WebApplication2.DAL;

namespace WebApplication2.DAL
{
    public class Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MyDBContext>
    {
        protected override void Seed(MyDBContext context)
        {
            //var movies = new List<Movie>
            //{
            //  new Movie { Id = 1, Name = "Shrek"},
            //  new Movie { Id = 2, Name = "Wall-e"}
            //};

            //movies.ForEach(m => context.Movies.Add(m));
            //context.SaveChanges();
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" },
                new Customer { Id= 3 ,Name ="Malala Mayambu"},
                new Customer { Id= 4 , Name ="Emelie Mayambu"}
            };
            customers.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();
        } 
    }
}