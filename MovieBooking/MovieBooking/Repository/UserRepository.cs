using Microsoft.EntityFrameworkCore;
using MovieBooking.Data;
using MovieBooking.Models;

namespace MovieBooking.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieDbContext _context;
        public UserRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            var dbUsers = _context.Users.Where(u => u.UserName == user.UserName).FirstOrDefaultAsync();
                if (dbUsers == null)
                {
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                    return user;
                }
            return null;
           
        }

        public void DeleteUser(int id)
        {
            var idFind = _context.Users.Find(id);
            if(idFind != null)
            {
                _context.Users.Remove(idFind);
                _context.SaveChanges();
            }
        }

        public async Task<User> GetUser(User user)
        {
            var dbUser = await _context.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefaultAsync();
            //var idfind = user.UserId;
            if(dbUser != null)
            {
                return dbUser;
            }
            return null;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
