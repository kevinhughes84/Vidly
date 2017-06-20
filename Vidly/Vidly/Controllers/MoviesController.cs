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
    }
}