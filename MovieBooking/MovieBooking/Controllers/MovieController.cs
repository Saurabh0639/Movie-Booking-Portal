using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieBooking.Repository;
using MovieBooking.Service;

namespace MovieBooking.Controllers
{
    [Produces("application/json")]
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }


    }
}
