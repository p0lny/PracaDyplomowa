using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities
{
    public class RegistrationToken
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public String Token { get; set; }
        public DateTime ExpiresAt { get; set; }



        public virtual User User{ get; set; }
    }
}
