using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.GenreType).ToList();
            return View(movies);
        }

        public ActionResult Details(int Id)
        {
            var movies = _context.Movies.Include(c => c.GenreType).FirstOrDefault(c => c.Id == Id);
            return View(movies);
        }

        public ActionResult New()
        {
            var genreTypes = _context.GenreTypes.ToList();
            var viewModel = new MovieFormViewModel
            {
                GenreTypes = _context.GenreTypes.ToList()
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == Id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel
            {
                Movies = movie,
                GenreTypes = _context.GenreTypes.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movies)
        {
            if(movies.Id == 0)
            {
                movies.DateAdded = DateTime.Now;
                _context.Movies.Add(movies);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movies.Id);
                movieInDb.Name = movies.Name;
                movieInDb.ReleaseDate = movies.ReleaseDate;
                movieInDb.GenreTypeId = movies.GenreTypeId;
                movieInDb.NumberInStock = movies.NumberInStock;

            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }
 
    }
}