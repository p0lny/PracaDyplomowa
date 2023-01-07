using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities
{
    public class SeatType
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String? Description { get; set; }



        public virtual ICollection<HallSeat> HallSeats { get; set; }
        public virtual SeatPrice SeatPrice { get; set; }
    }
}
