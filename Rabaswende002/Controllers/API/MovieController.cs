using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Rabaswende002.Dtos;
using Rabaswende002.Models;
using System.Data.Entity;


namespace Rabaswende002.Controllers.API
{
    public class MovieController : ApiController
    {
        public ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }


        // Get / api / movie 
        public IHttpActionResult GetMovies( string query = null)
      {
            // in order to make the include() work we have to inport the data entity, add the Genre from the Dto
            //in the Dto you will have to creat an other class Genre Dto. then put it in the movieDto( the method has to have the same name than the name in the model)
            // then you have to add the path in the maping profile. then you good to go 
            var moviesQuery = _context.Movies
                   .Include(m => m.Genre)
                   .Where(m => m.NumberAvailable > 0);

            if (!string.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
            
          

            var moviesDto = moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            return Ok(moviesDto);
        }

        // Get / api / movie / 1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }


        // add / api / movie / 1
        [HttpPost]
        public IHttpActionResult Createmovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            movieDto.AddedDate = DateTime.Now;
           var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            // return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
            return Created( new Uri(Request.RequestUri + "/" + movie.Id) , movieDto);
        }


        // updat / api / movie /  1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id , MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var toUpdatmovie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (toUpdatmovie == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Mapper.Map(movieDto, toUpdatmovie);
            _context.SaveChanges();

            return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>));
        }



        // Delete api / movi / 1
        [HttpDelete]
        public IHttpActionResult Deletmovie(int id)
        {
            var todelelte = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (todelelte == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(todelelte);
            _context.SaveChanges();

            return Ok();

        }
    }
}
