using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using VidlyF.Web.Models;

namespace VidlyF.Web.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }


        //GET /api/customers/1
        public Movie GetMovies(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return movie;
        }

        //POST /api/customers
        [HttpPost]
        public Movie CreateMovies(Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return movie;

        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateMovies(int id, Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            movieInDb.Name = movie.Name;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.DateAdded = movie.DateAdded;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.GenreId = movie.GenreId;

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteMovies(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }

}
