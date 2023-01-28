using CinemaAPI.Models;
using CinemaAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginUserDto dto)
        {
            var token = _userService.LoginUser(dto);
            return Ok(token);
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody] RegisterUserDto dto)
        {
            _userService.RegisterUser(dto);
            return Ok();
        }


        [HttpPost("password/reset")]
        public ActionResult RequestResetPassword([FromBody] ResetUserPasswordDto dto)
        {
            _userService.RequestResetUserPassword(dto);
            return Ok();
        }


        [HttpPut("password/reset")]
        public ActionResult ResetPassword([FromQuery] String token,[FromBody] ResetUserPasswordDto dto)
        {
            _userService.ResetUserPassword(token,dto);
            return Ok();
        }

        [HttpPut("password/change")]
        public ActionResult ChangePassword([FromBody] ChangeUserPasswordDto dto)
        {
            _userService.ChangeUserPassword(dto);
            return Ok();
        }


        [HttpPut("activate")]
        public ActionResult Activate([FromQuery] String token)
        {
            _userService.ActivateUser(token);
            return Ok();
        }

    }
}
