using MovieBooking.Models;

namespace MovieBooking.Repository
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetBookingByUserId(int userid);   //get list of booking by userid.....change it
        Task<Booking> CreateBooking(Booking booking);   //post 

        Task<Booking> GetBookingByOrderId(int orderid);     //getall Bookings

        //void DeleteBookingByUserId(int userid);         //delete bu userid
        void DeleteBookingByOrderId(int orderid);     //delete
        bool SaveChanges();
    }
}
