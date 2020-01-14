using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DAL;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class CustomersController : Controller
    {
        private MyDBContext _context; //access context class
        // GET: Customers/CustomerList

            public CustomersController()
        {
            _context = new MyDBContext();

        }
       /*dbcontext is a disposable object and so we have to 
        dispose it off properly*/
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershiptTypes = _context.MembershipTypes.ToList();
            var viewmodel = new NewCustomerViewModel
            {
                MembershipTypes = membershiptTypes
            };

            return View(viewmodel);
        }
        public ActionResult CustomerList()
        {
            /*Include() in order to accomodate the reference class membership
             so that the customer view can have access to it's entities 
             ToList() added in order to iterate through list*/
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
          

            return View(customers);
        }

       
        //GET: CustomersDetails//
        public ActionResult CustomerDetails(int? id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}
