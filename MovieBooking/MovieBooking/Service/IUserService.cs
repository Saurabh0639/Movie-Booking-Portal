using MovieBooking.Models;

namespace MovieBooking.Service
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);     
        Task<User> GetUser(User user);    
        void DeleteUser(int id);   
        bool SaveChanges();
    }
}
