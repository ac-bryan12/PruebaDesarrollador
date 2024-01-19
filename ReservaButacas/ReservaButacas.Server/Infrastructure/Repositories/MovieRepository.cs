using ReservaButacas.Server.Domain.Entities;
using ReservaButacas.Server.Domain.Interfaces.Services;

namespace ReservaButacas.Server.Infrastructure.ExternalServices
{
    public class MovieRepository : IMovieService
    {
        private List<MovieEntity> _movies;

        public MovieRepository()
        {
            _movies = new List<MovieEntity>();
        }

        public IEnumerable<MovieEntity> GetMovies()
        {
            return _movies;
        }

        public MovieEntity GetMovieById(int movieId)
        {

            return _movies.FirstOrDefault(movie => movie.Id == movieId);
        }

        public void AddMovie(MovieEntity movie)
        {
            _movies.Add(movie);
        }

        public bool UpdateMovie(MovieEntity movie)
        {
            var existingMovie = _movies.FirstOrDefault(movie => movie.Id == movie.Id);

            if (existingMovie != null)
            {
                existingMovie.Name = movie.Name;
                existingMovie.Genre = movie.Genre;
                existingMovie.LengthMinutes = movie.LengthMinutes;
                existingMovie.AllowedAge = movie.AllowedAge;
                return true;
            }
            return false;
        }

        public void DeleteMovie(int movieId)
        {
            var movieToRemove = _movies.FirstOrDefault(movie => movie.Id == movieId);
            if (movieToRemove != null)
            {
                _movies.Remove(movieToRemove);
            }
        }

    }

}
