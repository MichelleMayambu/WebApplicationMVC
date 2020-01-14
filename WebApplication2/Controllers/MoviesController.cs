using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.ViewModels;
using WebApplication2.DAL;

namespace WebApplication2.Controllers
{
    public class MoviesController : Controller
    {
        private MyDBContext _context;

        public MoviesController()
        {
            _context = new MyDBContext();
        }
     
        // GET: Movies/Random 
       
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Random()
        {

            var movies = _context.Movies.Include(m => m.GenreType).ToList();


            return View(movies);


        }
        public ActionResult MovieDetails(int id)
        {
            var movie = _context.Movies.Include(m => m.GenreType).SingleOrDefault(m => m.Id == id);

            return View(movie);
        }

        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate( int year, int month)
        {
            return Content(year + "/" + month);
        } 
    }
}