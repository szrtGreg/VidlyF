using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VidlyF.Web.Models;

namespace VidlyF.Web.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }


        public ActionResult Details(int id)
        {
            var movie = GetMovies().SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }


        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
              new Movie { Id = 1, Name = "Movie1" },
              new Movie { Id = 2, Name = "Movie2" }
            };
        }
    }
}