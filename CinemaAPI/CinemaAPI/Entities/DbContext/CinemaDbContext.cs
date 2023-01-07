using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities
{
    public class CinemaDbContext : DbContext
    {
        private readonly String _connectionString = "Server=(localdb)\\mssqllocaldb;Database=CinemaDb;Trusted_Connection=True";
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RegistrationToken> RegistrationTokens { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<HallSeat> HallSeats { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieDetails> MovieDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderReservation> orderReservations { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<SeatPrice> SeatPrices { get; set; }
        public DbSet<SeatType> SeatTypes { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieDetails>()
                .HasKey(e => e.MovieId);

            modelBuilder.Entity<OrderReservation>()
                .HasKey(e => new { e.OrderId, e.ReservationId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
