using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Models
{
    public class MovieInfoDto
    {
        public int Id { get; set; }

        public String Title { get; set; }
        public String UrlPoster { get; set; }
        public String UrlTrailer { get; set; }


        public string Description { get; set; }
    }
}
