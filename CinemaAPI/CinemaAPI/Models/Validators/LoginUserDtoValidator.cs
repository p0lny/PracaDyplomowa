using CinemaAPI.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Models.Validators
{
    public class LoginUserDtoValidator:AbstractValidator<LoginUserDto>
    {
        public LoginUserDtoValidator(ApiDbContext dbContext)
        {

        }
    }
}
