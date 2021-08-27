using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using Rabaswende002.Models;
using Rabaswende002.Dtos;
using AutoMapper;


namespace Rabaswende002.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

       
      

        // GET / api / customer
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customer
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);
        }

        // GET / api / customer / 1

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Mapper.Map<Customer, CustomerDto>(customer));

            
            }

        }


        // POST /api / customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customer.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);

        }
        // put / api / customer / 1
        
        
        [HttpPut]
        public void Put(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customer.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                Mapper.Map(customerDto, customerInDb);

                _context.SaveChanges();
            }
        }

        // revove / ap / customer / 1
        [HttpDelete]
        public IHttpActionResult DeletCustomer(int id)
        {
            var customerToRemove = _context.Customer.SingleOrDefault(c => c.Id == id);

            if (customerToRemove == null)
                return NotFound();
            _context.Customer.Remove(customerToRemove);
            _context.SaveChanges();
            return Ok();
        }
    }
}
