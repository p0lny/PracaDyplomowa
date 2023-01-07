using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities
{
    public class SeatPrice
    {
        public int Id { get; set; }
        public int SeatTypeId { get; set; }
        public double WeekPrice { get; set; }
        public double WeekendPrice { get; set; }



        public virtual SeatType SeatType { get; set; }
    }
}
