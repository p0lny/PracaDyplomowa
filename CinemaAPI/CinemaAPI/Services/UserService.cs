using CinemaAPI.Entities;
using CinemaAPI.Exceptions;
using CinemaAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ApiDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtTokenProviderService _jwtTokenProviderService;
        private readonly IEmailService _emailService;

        public UserService(ApiDbContext dbContext, IPasswordHasher<User> passwordHasher, IEmailService emailService, IJwtTokenProviderService jwtTokenProviderService)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _emailService = emailService;
            _jwtTokenProviderService = jwtTokenProviderService;
        }
        public string LoginUser(LoginUserDto dto)
        {
            if (_dbContext.Users.Any(e => e.Email == dto.Email))
            {
                var user = _dbContext.Users
                    .Include(e => e.Role)
                    .FirstOrDefault(e => e.Email == dto.Email);

                var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

                if (result == PasswordVerificationResult.Success)
                {
                    if (!user.IsActivated)
                    {
                        throw new UsetNotActivatedException(); //todo
                    }

                    var token = _jwtTokenProviderService.GetJwtForUser(user);

                    return token;

                }
            }

            throw new BadCredentialsException();
        }

        public void RegisterUser(RegisterUserDto dto)
        {
            var user = new User()
            {
                Email = dto.Email,
                Name = dto.Name,
                Surname = dto.Surname,
                RoleId = 3,
                IsActivated = false
            };

            var hashedPassword = _passwordHasher.HashPassword(user, dto.Password);
            user.PasswordHash = hashedPassword;

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            var registrationToken = new RegistrationToken()
            {
                UserId = user.Id,
                ExpiresAt = DateTime.Now.AddHours(24),
                Token = Guid.NewGuid().ToString()
            };
            _dbContext.RegistrationTokens.Add(registrationToken);
            _dbContext.SaveChanges();

            _emailService.SendVerificationEmail(user.Email, registrationToken);
        }

        public void ResetUserPassword(ResetUserPasswordDto dto, string token)
        {
            throw new NotImplementedException();
        }

        public void ChangeUserPassword(ChangeUserPasswordDto dto)
        {
            throw new NotImplementedException();
        }

        public void ActivateUser(string token)
        {
            throw new NotImplementedException();
        }

        public void RequestResetUserPassword(ResetUserPasswordDto dto)
        {
            throw new NotImplementedException();
        }

        public void ResetUserPassword(string token, ResetUserPasswordDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
