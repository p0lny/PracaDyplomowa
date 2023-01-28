using CinemaAPI.Entities;

namespace CinemaAPI.Services
{
    public interface IJwtTokenProviderService
    {
        public string GetJwtForUser(User user);

    }
}