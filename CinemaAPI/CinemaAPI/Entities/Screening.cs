using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities
{
    public class Screening
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int HallId { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }



        public virtual Movie Movie { get; set; }
        public virtual Hall Hall { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

    }
}
