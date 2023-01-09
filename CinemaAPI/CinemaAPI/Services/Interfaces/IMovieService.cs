namespace CinemaAPI.Services
{
    public interface IMovieService
    {
        void GetAllMovies();
        void GetMovie(int id);
        void GetMovieDetails(int id);
    }
}