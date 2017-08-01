using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VidlyF.Web.Models;
using VidlyF.Web.ViewModels;

namespace VidlyF.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(g => g.Genre).ToList();

            return View(movies);
        }


        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        // GET: Movie Form
        public ActionResult Create()
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = _context.Genres.ToList(),
                Heading = "Add Movie"
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("MovieForm", viewModel);
            };

            var movie = new Movie
            {
                GenreId = viewModel.GenreId,
                Name = viewModel.Name,
                ReleaseDate = (DateTime)viewModel.ReleaseDate,
                DateAdded = DateTime.Now,
                NumberInStock = (byte)viewModel.NumberInStock,
            };

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        // GET: Customers Form
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(c => c.Id == id);
            var viewModel = new MovieFormViewModel
            {
                Id = movie.Id,
                Heading = "Edit Movie",
                Genres = _context.Genres.ToList(),
                Name = movie.Name,
                GenreId = movie.GenreId,
                ReleaseDate = movie.ReleaseDate,
                NumberInStock = movie.NumberInStock
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MovieFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("MovieForm", viewModel);
            }

            var movie = _context.Movies.Single(c => c.Id == viewModel.Id);

            movie.ReleaseDate= (DateTime)viewModel.ReleaseDate;
            movie.GenreId = viewModel.GenreId;
            movie.Name = viewModel.Name;
            movie.NumberInStock = (byte)viewModel.NumberInStock;

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }


        //private IEnumerable<Movie> GetMovies()
        //{
        //    return new List<Movie>
        //    {
        //      new Movie { Id = 1, Name = "Movie1" },
        //      new Movie { Id = 2, Name = "Movie2" }
        //    };
        //}
    }
}