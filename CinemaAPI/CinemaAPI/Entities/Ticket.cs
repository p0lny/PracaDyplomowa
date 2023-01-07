using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public String Code { get; set; }
        public int ReservationId { get; set; }
        public bool IsValid { get; set; }



        public virtual Reservation Reservation { get; set; }

    }
}
