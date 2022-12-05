using AutoMapper;
using MovieBooking.Models;
using MovieBooking.Repository;

namespace MovieBooking.Service
{
    public class BookingService : IBookingService
    {
        private IMapper _mapper;

        private IBookingRepository _bookingRepository;
        public BookingService(IMapper mapper, IBookingRepository bookingRepository)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
        }


        public async Task<Booking> CreateBooking(Booking booking)
        {
            var bookingService = _mapper.Map<Booking>(booking);
            return await _bookingRepository.CreateBooking(bookingService);
        }

        public void DeleteBookingByOrderId(int orderid)
        {
            _mapper.Map<Booking>(orderid);
            _bookingRepository.DeleteBookingByOrderId(orderid);
        }

        public async Task<Booking> GetBookingByOrderId(int orderid)
        {
            var bookingByOrderId = await _bookingRepository.GetBookingByOrderId(orderid);
            var bookingService = _mapper.Map<Booking>(bookingByOrderId);
            return bookingService;

        }

        public async Task<IEnumerable<Booking>> GetBookingByUserId(int userid)
        {
            var bookingByUser =await _bookingRepository.GetBookingByUserId(userid);
            var bookingService = _mapper.Map<Booking>(bookingByUser);
            return (IEnumerable<Booking>)bookingService;
        }

        public bool SaveChanges()
        {
            return _bookingRepository.SaveChanges();
        }
    }
}
