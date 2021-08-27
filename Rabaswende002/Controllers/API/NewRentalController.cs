using Rabaswende002.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Rabaswende002.Dtos;
using AutoMapper;

namespace Rabaswende002.Controllers.API
{
    public class NewRentalController : ApiController
    {

        private ApplicationDbContext _context;

        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreatRentals(NewRentalDto newRental)
        {
            //  var customer = _context.Customer.Single(c => c.Id == newRental.CustomerId );
            //      var movies = _context.Movies.Where(m => newRental.MovieId.Contains(m.Id)).ToList();
          
            // THA IS THE SECURE MODE
       //     if (newRental.MovieId.Count == 0)
        //        return BadRequest("no movie Ids had been given.");

            var customer= _context.Customer.SingleOrDefault(
               c => c.Id == newRental.CustomerId);
            if (customer == null)
                return BadRequest("Customer id is invlide");

            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList();


            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("Movies is not available");

            foreach (var movie in movies)
            {
                movie.NumberAvailable--;
                var rental = new Rental
                {
                    CustomerId = customer,
                    MovieIds = movie,
                    DateRented = DateTime.Now

                };

                _context.Rentals.Add(rental);

                

            }

            _context.SaveChanges();
            
               return Ok();

            
        }


        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // get / api /customers & movies
       

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }


        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}