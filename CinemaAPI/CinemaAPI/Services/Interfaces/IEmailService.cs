using CinemaAPI.Entities;

namespace CinemaAPI.Services
{
    public interface IEmailService
    {
        void SendVerificationEmail(string email, RegistrationToken registrationToken);

    }
}