using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities
{
    public class OrderReservation
    {
        public int OrderId { get; set; }
        public int ReservationId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
