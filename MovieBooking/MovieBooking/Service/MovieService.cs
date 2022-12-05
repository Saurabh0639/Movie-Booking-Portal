using MovieBooking.Models;

namespace MovieBooking.Service
{
    public class MovieService : IMovieService
    {
        public Task<Film> CreateFilm(Film film)
        {
            throw new NotImplementedException();
        }

        public void DeleteFilmById(int filmid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Film>> GetAllFilm()
        {
            throw new NotImplementedException();
        }

        public Task<Film> GetFilmById(int filmid)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
