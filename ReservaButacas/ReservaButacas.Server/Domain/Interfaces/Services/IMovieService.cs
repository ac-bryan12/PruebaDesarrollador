using ReservaButacas.Server.Domain.Entities;

namespace ReservaButacas.Server.Domain.Interfaces.Services
{
    public interface IMovieService
    {
        IEnumerable<MovieEntity> GetMovies();
        MovieEntity GetMovieById(int movieId);
        void AddMovie(MovieEntity movie);
        bool UpdateMovie(MovieEntity movie);
        void DeleteMovie(int movieId);
    }
}
