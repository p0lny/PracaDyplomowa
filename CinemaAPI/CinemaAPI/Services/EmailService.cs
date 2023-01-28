using CinemaAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CinemaAPI.Services
{
    public class EmailService : IEmailService
    {

        public void SendVerificationEmail(string email, RegistrationToken registrationToken)
        {
            MailAddress to = new MailAddress(email);
            MailAddress from = new MailAddress("bazafilmowa.noreply@gmail.com");
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Potwierdzenie adresu email - Baza filmowa";
            message.Body = $"Potwierdź: http://localhost:3000/activate/{registrationToken.Token}";
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("bazafilmowa.noreply@gmail.com", "lzswsqesvcunhhjl"),
                EnableSsl = true
            };

            client.Send(message);
        }
    }
}
