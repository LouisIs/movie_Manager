using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rabaswende002.Models;
using System.Data.Entity;
using Rabaswende002.ViewModel;


namespace Rabaswende002.Controllers
{
   

    public class MovieController : Controller
    {

        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movie
       [Authorize(Roles = roleName.CaneManageMovie)]
        public ActionResult New()
        {
            var Genre = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel()
            {              
                Genres = Genre,
                Title = "New Movie"    
                
            };
            return View("MovieForm", viewModel);
        }



        // Edit Fuction
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewmodel = new NewMovieViewModel(movie)
            {
                
                Genres = _context.Genres.ToList(),
                Title = "Edit Movie",
            };
            return View("MovieForm", viewmodel);
        }



        // http request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel(movie)
                {
                   
                    
                    Genres = _context.Genres.ToList(),
                    Title = "Add new Movie",
                };
                return View ("MovieForm", viewModel);
            }


            if(movie.Id == 0)
            {
                movie.AddedDate = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.AddedDate = DateTime.Now;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.InStock = movie.InStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }


        public ViewResult Index()
        {
            if (User.IsInRole("canManageMovies"))
                return View("Index");
            return View("ReadOnlyMovies");
        }
        public ActionResult Details(int id)
        {
            var detail = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (detail == null)
                return HttpNotFound();
            

          return View(detail);

        }


       

           

            
        
       

       
    }
}