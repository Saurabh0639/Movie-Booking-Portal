using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieBooking.Models;
using MovieBooking.Repository;
using MovieBooking.Service;

namespace MovieBooking.Controllers
{
    [Produces("application/json")]
    [Route("api/booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        public readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService=bookingService;
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> AddBooking(Booking booking)
        {
            try
            {
                if (booking == null)
                {
                    return NoContent();
                }
                if (ModelState.IsValid)
                {
                    int id =new();
                    booking.OrderId = id;
                    await _bookingService.CreateBooking(booking);
                    return CreatedAtAction("GetBooking",new {id =booking.OrderId}, booking);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("orderid")]
        public async Task<ActionResult> DeleteBooking(int orderid)
        {
            try
            {
                var orderbyid = await _bookingService.GetBookingByOrderId(orderid);
                if (orderbyid == null)
                {
                    return NotFound();
                }
                _bookingService.DeleteBookingByOrderId(orderid);
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("userid")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookinig(int userid)
        {
            try
            {
                var getallbooking = await _bookingService.GetBookingByUserId(userid);
                if(getallbooking == null)
                {
                    return NotFound();
                }
                return Ok(getallbooking.OrderBy(getallbooking => getallbooking.OrderId).ToList());
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


    }
}
