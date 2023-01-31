using CinemaAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Controllers
{
    [Route("api/movies")]
    [ApiController]
    [AllowAnonymous]
    public class MovieController : ControllerBase
    {

        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public ActionResult GetAllMovies()
        {
            var movies = _movieService.GetAllMovies();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public ActionResult GetMovie([FromRoute] int id)
        {
            var movie = _movieService.GetMovie(id);
            return Ok(movie);
        }

        [HttpGet("details/{id}")]
        public ActionResult GetMovieDetails([FromRoute] int id)
        {
            _movieService.GetMovieDetails(id);
            return Ok();
        }

    }
}
