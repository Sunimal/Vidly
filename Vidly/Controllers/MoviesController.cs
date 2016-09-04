using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
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
            var movies = GetMovies();
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
    }
}