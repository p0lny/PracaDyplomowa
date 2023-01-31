using CinemaAPI.Models;
using System.Collections.Generic;

namespace CinemaAPI.Services
{
    public interface IScreeningService
    {
        IEnumerable<ScreeningInfoDto> GetAllScreenings();
    }
}