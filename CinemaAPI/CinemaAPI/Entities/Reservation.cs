using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ScreeningId { get; set; }
        public int HallSeatId { get; set; }



        public virtual Ticket Ticket { get; set; }
        public virtual User User { get; set; }
        public virtual Screening Screening { get; set; }
        public virtual ICollection<OrderReservation> OrderReservations { get; set; }
        public virtual HallSeat HallSeat { get; set; }
    }
}
