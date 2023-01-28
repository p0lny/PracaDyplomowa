using CinemaAPI.Models;

namespace CinemaAPI.Services
{
    public interface IUserService
    {
        void RegisterUser(RegisterUserDto dto);
        string LoginUser(LoginUserDto dto);
        void ResetUserPassword(ResetUserPasswordDto dto, string token);
        void ChangeUserPassword(ChangeUserPasswordDto dto);
        void ActivateUser(string token);
        void RequestResetUserPassword(ResetUserPasswordDto dto);
        void ResetUserPassword(string token, ResetUserPasswordDto dto);
    }
}