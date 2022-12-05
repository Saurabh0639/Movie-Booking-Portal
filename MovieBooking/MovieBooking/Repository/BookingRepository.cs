using Microsoft.EntityFrameworkCore;
using MovieBooking.Data;
using MovieBooking.Models;

namespace MovieBooking.Repository
{
    public class BookingRepository : IBookingRepository
    {

        private readonly MovieDbContext _context;

        public BookingRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<Booking> CreateBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async void DeleteBookingByOrderId(int orderid)
        {
            var bookingId = _context.Bookings.Find(orderid);
            if ( bookingId != null)
            {
                _context.Bookings.Remove(bookingId);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Booking> GetBookingByOrderId(int orderid)
        {
            return await _context.Bookings.FirstOrDefaultAsync(b => b.OrderId == orderid);
        }

        public async Task<IEnumerable<Booking>> GetBookingByUserId(int userid)
        {
            var ToGetAllUser = await _context.Bookings.ToListAsync();
            var ToGetUserById = ToGetAllUser.Select(b => b.UserId ==userid);
            return (IEnumerable<Booking>)ToGetUserById;

            //return (IEnumerable<Booking>)(await _context.Bookings.ToListAsync()).Select(b => b.UserId == userid );
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}
