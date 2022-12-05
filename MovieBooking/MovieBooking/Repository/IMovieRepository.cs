using MovieBooking.Models;

namespace MovieBooking.Repository
{
    public interface IMovieRepository
    {
        Task<Film> CreateFilm(Film film);   //post
        void DeleteFilmById(int filmid);    //delete
        Task<IEnumerable<Film>> GetAllFilm();   //getall
        Task<Film> GetFilmById(int filmid);     //get
        bool SaveChanges();
    }
}
