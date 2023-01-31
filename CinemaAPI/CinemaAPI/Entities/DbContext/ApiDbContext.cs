using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities
{
    public class ApiDbContext : DbContext
    {

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
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
        public DbSet<OrderReservation> OrderReservations { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<SeatPrice> SeatPrices { get; set; }
        public DbSet<SeatType> SeatTypes { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<MovieDetails>()
                .HasKey(e => e.MovieId);

            modelBuilder.Entity<OrderReservation>()
                .HasKey(e => new { e.OrderId, e.ReservationId });
        }

        public static SqlConnectionStringBuilder GetSqlConnectionString()
        {
            var connectionString = new SqlConnectionStringBuilder()
            {
                DataSource = "ELPLC-0408\\SQLEXPRESS2014",
                UserID = "sa",
                Password = "5540",
                InitialCatalog = "CinemaApiDb",
                Encrypt = false,
            };
            connectionString.Pooling = true;
            return connectionString;
        }
    }
}
