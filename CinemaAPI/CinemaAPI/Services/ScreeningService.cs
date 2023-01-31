using CinemaAPI.Entities;
using CinemaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Services
{
    public class ScreeningService : IScreeningService
    {
        ApiDbContext _apiDbContext;
        public ScreeningService(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public IEnumerable<ScreeningInfoDto> GetAllScreenings()
        {

            List<ScreeningInfoDto> dtos = new();

            var screenings = _apiDbContext.Screenings
                .Include(e => e.Movie)
                .Include(e => e.Hall)
                .ToList();

            foreach(var screening in screenings)
            {
                dtos.Add(new ScreeningInfoDto()
                {
                    Id = screening.Movie.Id,
                    Title = screening.Movie.Title,
                    HallName = screening.Hall.Name,
                    BeginTime = screening.BeginTime,
                    EndTime = screening.EndTime,
                    UrlPoster = screening.Movie.UrlPoster,
                    UrlTrailer = screening.Movie.UrlTrailer
                });
            }

            return dtos;            
        }
    }
}
