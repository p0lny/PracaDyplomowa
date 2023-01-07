using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public String TrackingNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public int OrderStatusId { get; set; }




        public virtual OrderStatus OrderStatus { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderReservation> OrderReservations { get; set; }

    }
}
