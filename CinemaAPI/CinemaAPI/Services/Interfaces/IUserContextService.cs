using System.Security.Claims;

namespace CinemaAPI.Services
{
    public interface IUserContextService
    {
        public ClaimsPrincipal User { get; }
        public int? GetUserId { get; }
    }
}