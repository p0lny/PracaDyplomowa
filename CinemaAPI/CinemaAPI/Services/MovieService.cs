using CinemaAPI.Entities;
using CinemaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Services
{
    public class MovieService : IMovieService
    {
        ApiDbContext _apiDbContext;
        public MovieService(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            var movies = _apiDbContext.Movies.ToList();
            return movies;
        }

        public MovieInfoDto GetMovie(int id)
        {
            var movie = _apiDbContext.Movies.Where(e => e.Id == id).Include(e=>e.MovieDetails).FirstOrDefault();

            if(movie != null)
            {
                MovieInfoDto dto = new()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Description = movie.MovieDetails.Description,
                    UrlPoster = movie.UrlPoster,
                    UrlTrailer = movie.UrlTrailer
                };
                return dto;

            }

            return null;

        }

        public MovieDetails GetMovieDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
