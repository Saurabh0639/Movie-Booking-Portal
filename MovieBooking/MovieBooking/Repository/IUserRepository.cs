using MovieBooking.Models;

namespace MovieBooking.Repository
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);      //post
        Task<User> GetUser(User user);      //get// again check
        void DeleteUser(int id);     //delete
        bool SaveChanges();
    }
}
