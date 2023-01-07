using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities
{
    public class HallSeat
    {
        public int Id { get; set; }
        public int HallId { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public int SeatTypeId { get; set; }



        public virtual SeatType SeatType { get; set; }
        public virtual Hall Hall { get; set; }
        public virtual Reservation Reservation { get; set; }

    }
}
