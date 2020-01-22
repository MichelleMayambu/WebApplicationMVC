﻿using System;
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
    public class MovieController : Controller
    {
        private MyDBContext _context;

        public MovieController()
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
        public ActionResult New()
        {
            var genreTypes = _context.GenreTypes.ToList();
            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                GenreTypes = genreTypes
            };
            return View("MovieForm", viewModel);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            //Model.State to check validation from the model
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    GenreTypes = _context.GenreTypes.ToList()
                };

                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreTypeId = movie.GenreTypeId;
                movieInDb.ReleaseDate = movie.ReleaseDate;    
                movieInDb.NumberInStock = movie.NumberInStock;
              
            }

                _context.SaveChanges();

                 return RedirectToAction("Random", "Movies");
        }
        public ActionResult Edit(int id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movies == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel
            {
                Movie = movies,
                GenreTypes = _context.GenreTypes.ToList()

            };
            /*this will return the form with the customer details
             based on the customerID*/
            return View("MovieForm", viewModel);
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