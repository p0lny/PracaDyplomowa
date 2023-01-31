namespace CinemaClient
{
    public class ScreeningInfo
    {
        public int Id { get; set; }

        public String Title { get; set; }
        public String UrlPoster { get; set; }
        public String UrlTrailer { get; set; }

        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }

        public string HallName { get; set; }
    }
}