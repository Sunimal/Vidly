using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new Models.ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "The Matrix"
            };

            var customers = new List<Customer>()
            {
                new Customer { Name = "Sunimal" },
                new Customer { Name = "Dilhan" }
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();
            return View(movies);
        }
        
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "The Matrix" },
                new Movie { Id = 2, Name = "Inception" }
            };
        }

        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include( c => c.Genre).SingleOrDefault(c => c.Id == Id);
            return View(movie);
        }        
    }
}