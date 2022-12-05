using Microsoft.EntityFrameworkCore;
using MovieBooking.Data;
using MovieBooking.Models;

namespace MovieBooking.Repository
{
    public class MovieRepository : IMovieRepository
    {

        private readonly MovieDbContext _context;
        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<Film> CreateFilm(Film film)
        {
            _context.Films.Add(film);
            await _context.SaveChangesAsync();
            return film;
        }

        public void DeleteFilmById(int filmid)
        {
            var idFind = _context.Films.Find(filmid);
            if(idFind != null)
            {
                _context.Films.Remove(idFind);
                _context.SaveChanges();
            }
            
        }

        public async Task<IEnumerable<Film>> GetAllFilm()
        {
            return await _context.Films.ToListAsync();
        }

        public async Task<Film> GetFilmById(int filmid)
        {
            return await _context.Films.FirstOrDefaultAsync(u => u.FilmId == filmid);
            
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
