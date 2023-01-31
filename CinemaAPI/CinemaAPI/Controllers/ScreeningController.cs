using CinemaAPI.Models;
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
    [Route("api/screenings")]
    [ApiController]
    [AllowAnonymous]
    public class ScreeningController : ControllerBase
    {
        IScreeningService _screeningService;
        public ScreeningController(IScreeningService screeningService)
        {
            _screeningService = screeningService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ScreeningInfoDto>> GetAllScreenings()
        {
            var screenings = _screeningService.GetAllScreenings();
            return Ok(screenings);
        }

    }
}
