using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Model;
using MovieManagement.Services;

namespace MovieManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheaterController : ControllerBase
    {
        private TheaterService _theaterService;
        public TheaterController(TheaterService theaterService) { _theaterService = theaterService; }
        [HttpGet("GetTheaters")]
        public async Task<List<Theater>> GetTheaters()
        {
            return await _theaterService.GetTheater();
        }

        [HttpGet("GetTheatersById")]
        public async Task<List<Theater>> GetTheatersById(int movieId)
        {
            return await _theaterService.GetTheaterById(movieId);
        }
        [HttpGet("GetTheatersByLocation")]
        public async Task<List<Theater>> GetTheatersByLocation(string location)
        {
            return await _theaterService.GetTheaterByLocation(location);
        }

    }
}
