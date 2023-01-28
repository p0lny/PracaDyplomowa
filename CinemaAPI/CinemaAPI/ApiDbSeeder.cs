using CinemaAPI.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI
{
    public class ApiDbSeeder
    {
        private readonly ApiDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public ApiDbSeeder(ApiDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                _dbContext.Database.EnsureDeleted();
                _dbContext.Database.EnsureCreated();

                if (!_dbContext.Cinemas.Any())
                {
                    var cinemas = GetCinemas();
                    _dbContext.Cinemas.AddRange(cinemas);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Users.Any())
                {
                    var users = GetUsers();
                    _dbContext.Users.AddRange(users);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Movies.Any())
                {
                    var movies = GetMovies();
                    _dbContext.Movies.AddRange(movies);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Screenings.Any())
                {
                    var screenings = GetScreenings();
                    _dbContext.Screenings.AddRange(screenings);
                    _dbContext.SaveChanges();
                }

            }

        }

        private IEnumerable<Screening> GetScreenings()
        {
            var movies = _dbContext.Movies.Take(1).ToList();
            var halls = _dbContext.Halls.Take(2).ToList();
            var screenings = new List<Screening>();

            if (movies.Count == 1 && halls.Count == 2)
            {
                var today = DateTime.Now;
                var movieDuration = movies[0].MovieDetails.Duration;

                screenings = new List<Screening>()
                {
                    new Screening()
                    {
                        BeginTime = new DateTime(today.Year,today.Month,today.Day, 10,0,0).AddDays(1),
                        EndTime = new DateTime(today.Year,today.Month,today.Day, 10,0,0).AddDays(1).AddMinutes(Math.Ceiling(movieDuration.TotalMinutes/15)*15),
                        Movie = movies[0],
                        Hall = halls[0]
                    },

                    new Screening()
                    {
                        BeginTime = new DateTime(today.Year,today.Month,today.Day, 10,30,0).AddDays(1),
                        EndTime = new DateTime(today.Year,today.Month,today.Day, 10,30,0).AddDays(1).AddMinutes(Math.Ceiling(movieDuration.TotalMinutes/15)*15),
                        Movie = movies[0],
                        Hall = halls[1]
                    },

                   new Screening()
                    {
                        BeginTime = new DateTime(today.Year,today.Month,today.Day, 15,30,0).AddDays(1),
                        EndTime = new DateTime(today.Year,today.Month,today.Day, 15,30,0).AddDays(1).AddMinutes(Math.Ceiling(movieDuration.TotalMinutes/15)*15),
                        Movie = movies[0],
                        Hall = halls[1]
                    },

                    new Screening()
                    {
                        BeginTime = new DateTime(today.Year,today.Month,today.Day, 15,45,0).AddDays(1),
                        EndTime = new DateTime(today.Year,today.Month,today.Day, 15,45,0).AddDays(1).AddMinutes(Math.Ceiling(movieDuration.TotalMinutes/15)*15),
                        Movie = movies[0],
                        Hall = halls[0]
                    },


                };

                _dbContext.Screenings.AddRange();
            }

            return screenings;
        }

        private IEnumerable<Movie> GetMovies()
        {
            var movies = new List<Movie>()
            {
                new Movie()
                {
                    Title = "Avatar: Istota wody",
                    UrlPoster = "https://th.bing.com/th/id/R.11ece4dba8c4e82285cc94fc294b44e1?rik=nl%2buEBHhCmlCKg&pid=ImgRaw&r=0",
                    UrlTrailer = "https://www.youtube.com/watch?v=j2iL9JBSCo4",
                    MovieDetails = new MovieDetails()
                    {
                        Genre = "Science-Fiction",
                        AgeRestriction = 12,
                        Duration = new TimeSpan(0,193,0),
                        Description = "Akcja filmu „Avatar: Istota wody” rozgrywa się ponad dziesięć lat po wydarzeniach z pierwszej części. To opowieść o rodzinie Jake’a i Neytiri oraz ich staraniach, by zapewnić bezpieczeństwo sobie i swoim dzieciom, mimo tragedii, których wspólnie doświadczają i bitew, które muszą stoczyć, aby przeżyć.W filmie wyreżyserowanym przez Jamesa Camerona, wyprodukowanym przez Camerona i Jona Landau, występują: Zoe Saldana, Sam Worthington, Sigourney Weaver, Stephen Lang, Cliff Curtis, Joel David Moore, CCH Pounder, Edie Falco, Jemaine Clement i Kate Winslet."
                    },
                }
            };

            return movies;
        }

        private IEnumerable<User> GetUsers()
        {
            var admin = new User()
            {
                Name = "Admin",
                Email = "admin@mail.com",
                IsActivated = true,
                Role = new Role()
                {
                    Name = "Admin",
                    Description = "Administrator"
                },
                Surname = String.Empty
            };

            var user = new User()
            {
                Name = "Jan",
                Surname = "Kowalski",
                Email = "jankowalski@mail.com",
                IsActivated = true,
                Role = new Role()
                {
                    Name = "User",
                    Description = "Regular user"
                }
            };

            admin.PasswordHash = _passwordHasher.HashPassword(admin, "admin");
            user.PasswordHash = _passwordHasher.HashPassword(user, "user");

            var users = new List<User>()
            {
                admin,
                user,
            };


            return users;
        }

        private IEnumerable<Cinema> GetCinemas()
        {
            var cinemas = new List<Cinema>() {
                new Cinema()
                {
                  Name = "TestoweKino",
                  Email = "test@mail.com",
                  OpeningTime = new TimeSpan(10,0,0),
                  ClosingTime = new TimeSpan(22,0,0),
                  PhoneNumber = "123456789",
                  Address = new Address()
                  {
                      City = "Tarnów",
                      PostalCode ="33-100",
                      Street = "Krakowska 123",
                  },
                  Halls = new List<Hall>()
                  {
                      new Hall()
                      {
                          Name = "Big hall",
                          HallSeats = (ICollection<HallSeat>)GetBigHallSeats(),
                      },
                      new Hall()
                      {
                          Name = "Small hall",
                          HallSeats = (ICollection<HallSeat>)GetSmallHallSeats()
                      }
                  }
                }
            };
            return cinemas;
        }

        private IEnumerable<HallSeat> GetSmallHallSeats()
        {
            SeatType standardSeatType = new SeatType()
            {
                Name = "Standard",
                SeatPrice = new SeatPrice()
                {
                    WeekPrice = 15.99,
                    WeekendPrice = 20.99
                },
                Description = "Standard seat at small hall",
            };


            SeatType vipSeatType = new SeatType()
            {
                Name = "VIP",
                SeatPrice = new SeatPrice()
                {
                    WeekPrice = 20.99,
                    WeekendPrice = 25.99
                },
                Description = "Extra comfort, leather covered seat at small hall",
            };



            var seats = new List<HallSeat>();

            for (int r = 1; r <= 5; r++)
            {
                for (int c = 1; c <= 7; c++)
                {

                    var seatType = standardSeatType;

                    if (r == 4)
                    {
                        seatType = vipSeatType;
                    }

                    seats.Add(
                        new HallSeat()
                        {
                            Column = c,
                            Row = r,
                            SeatType = seatType,
                        });
                }
            }

            return seats;
        }

        private IEnumerable<HallSeat> GetBigHallSeats()
        {
            SeatType standardSeatType = new SeatType()
            {
                Name = "Standard",
                SeatPrice = new SeatPrice()
                {
                    WeekPrice = 15.99,
                    WeekendPrice = 20.99
                },
                Description = "Standard seat at big hall",
            };


            SeatType vipSeatType = new SeatType()
            {
                Name = "VIP",
                SeatPrice = new SeatPrice()
                {
                    WeekPrice = 20.99,
                    WeekendPrice = 25.99
                },
                Description = "Extra comfort, leather covered seat at big hall",
            };



            var seats = new List<HallSeat>();

            for (int r = 1; r <= 7; r++)
            {
                for (int c = 1; c <= 13; c++)
                {

                    var seatType = standardSeatType;

                    if (r == 7 || r == 8)
                    {
                        seatType = vipSeatType;
                    }

                    seats.Add(
                        new HallSeat()
                        {
                            Column = c,
                            Row = r,
                            SeatType = seatType,
                        });
                }
            }

            return seats;
        }
    }
}
