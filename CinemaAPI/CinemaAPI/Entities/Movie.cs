using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String UrlPoster { get; set; }
        public String UrlTrailer { get; set; }
        public int MovieDetailsId { get; set; }


        public virtual ICollection<Screening> Screenings { get; set; }
        public virtual MovieDetails MovieDetails { get; set; }
    }
}
