using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ViewResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            return Content($"id={id}");
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content($"pageIndex={pageIndex}&sortBy={sortBy}");
        }

        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content($"{year}/{month}");
        }
    }
}