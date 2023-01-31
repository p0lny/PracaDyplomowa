using CinemaAPI.Entities;
using CinemaAPI.Models;
using System.Collections.Generic;

namespace CinemaAPI.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAllMovies();
        MovieInfoDto GetMovie(int id);
        MovieDetails GetMovieDetails(int id);
    }
}