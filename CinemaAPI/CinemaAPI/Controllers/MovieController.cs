using CinemaAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("/movies")]
        public ActionResult GetAllMovies()
        {
            _movieService.GetAllMovies();
            return Ok();
        }

        [HttpGet("/movie/{id}")]
        public ActionResult GetMovie([FromRoute] int id)
        {
            _movieService.GetMovie(id);
            return Ok();
        }

        [HttpGet("/movie/details/{id}")]
        public ActionResult GetMovieDetails([FromRoute] int id)
        {
            _movieService.GetMovieDetails(id);
            return Ok();
        }

    }
}
