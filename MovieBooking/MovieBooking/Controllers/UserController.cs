using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieBooking.Models;
using MovieBooking.Repository;
using MovieBooking.Service;

namespace MovieBooking.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            if(user == null)
            {
                return NoContent();
            }
            else if (ModelState.IsValid)
            {
                int id =new();
                user.UserId = id;
                await _userService.CreateUser(user);
                return CreatedAtAction("GetUser", new { userid = user.UserId }, user);
            }
            else
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUser(User user)
        {
            try
            {
                var userModel = await _userService.GetUser(user);
                if(userModel == null)
                {
                    return NotFound();
                }
                return (userModel);
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        


    }
}
