﻿using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.DAL;
using WebApplication2.Dtos;
using WebApplication2.Models;

namespace WebApplication2.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private MyDBContext _context;    

        public CustomersController()
        {
            _context = new MyDBContext();
        }
        //GET /api/Customers
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.Customers
               .Include(c => c.MembershipType)
               .ToList()
               .Select(Mapper.Map<Customer, CustomerDto>);


            return Ok(customerDtos); 
           

        }
        //GET /api/Customers/1
        public CustomerDto GetCustomer( int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer,CustomerDto>(customer);
        }
        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
               

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            //use 
            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDto);
        }
        // PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer( int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();
        }
        //DELETE api/customers/1
        [HttpDelete]
        public void DeleteCustomer( int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
           
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

        }
    }

}
