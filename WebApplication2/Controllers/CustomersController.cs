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

        public ActionResult CustomerForm()
        {
            var membershiptTypes = _context.MembershipTypes.ToList();
            var viewmodel = new CustomerFormViewModel
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
        /*to make sure that this action only runs as a post
         * MODEL BINDING *
         MVC framework will bind Customer to the request data
         create action is the action happening on the form that was described in the view*/
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            //Model.State to check validation from the model
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
               
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                /* manually set customer objects*/
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
          /*generate sql statements at runtime and make
           alterations to database ans save new entry data on
           on the form*/
           
            _context.SaveChanges();
            return RedirectToAction("CustomerList", "Customers");
        } 
       public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };
            /*this will return the form with the customer details
             based on the customerID*/
            return View("CustomerForm", viewModel);
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
