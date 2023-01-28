using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities
{
    public class MovieDetails
    {
        public int MovieId { get; set; }
        public String Description { get; set; }
        public TimeSpan Duration { get; set; }
        public byte AgeRestriction { get; set; }
        public string Genre { get; set; }


        public virtual Movie Movie { get; set; }
    }
}
