using CinemaAPI.Models;

namespace CinemaAPI.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
        void LoginUser(LoginUserDto dto);
    }
}