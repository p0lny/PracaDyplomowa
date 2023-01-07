using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities
{
    public class Hall
    {
        public int Id { get; set; }
        public int CinemaId { get; set; }
        public string Name { get; set; }



        public virtual Cinema Cinema { get; set; }
        public virtual ICollection<Screening> Screenings { get; set; }
        public virtual ICollection<HallSeat> HallSeats { get; set; }
    }
}
