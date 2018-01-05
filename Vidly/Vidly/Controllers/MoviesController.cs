using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Movies

        public ActionResult Edit(int id)
        {
            return Content($"id={id}");
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m=>m.Genre).ToList();

            return View(movies);
        }

        [Route(@"movies/released/{year:regex(\d{4})}/{month:regex(\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content($"{year}/{month}");
        }
    }
}