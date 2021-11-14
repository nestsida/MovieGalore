using Microsoft.AspNetCore.Mvc;
using MovieGalore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieGalore.Controllers
{
    public class MovieController : Controller
    {

        private readonly IMovieList repo;

        public MovieController(IMovieList repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var movie = repo.GetMovies();

            return View(movie);
        }
        public IActionResult ViewMovie(int id)
        {
            var movie = repo.GetMovies(id);

            return View(movie);
        }
        public IActionResult UpdateMovies(int id)
        {
           Movies movie = repo.GetMovies(id);

            if (movie == null)
            {
                return View("MovieNotFound");
            }

            return View(movie);
        }
        public IActionResult UpdateMoviesToDatabase(Movies movie)
        {
            repo.UpdateMovies(movie);

            return RedirectToAction("ViewMovie", new { id = movie.ID });
        }
        public IActionResult InsertMovie()
        {
            var movie = repo.AssignCategory();

            return View(movie);
        }
        public IActionResult InsertProductToDatabase(Movies movieToInsert)
        {
            repo.InsertMovie(movieToInsert);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteMovie(Movies movie)
        {
            repo.DeleteMovie(movie);

            return RedirectToAction("Index");
        }







    }
}
