using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities
{
    public class Cinema
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int AddressId { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }




        public virtual ICollection<Hall> Halls { get; set; }
        public virtual Address Address { get; set; }

    }
}
