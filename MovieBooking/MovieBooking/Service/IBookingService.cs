using MovieBooking.Models;

namespace MovieBooking.Service
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetBookingByUserId(int userid);  
        Task<Booking> CreateBooking(Booking booking);   

        Task<Booking> GetBookingByOrderId(int orderid);     

        //void DeleteBookingByUserId(int userid);         //delete bu userid
        void DeleteBookingByOrderId(int orderid);     
        bool SaveChanges();
    }
}
