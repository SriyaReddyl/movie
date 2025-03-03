using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Model;
using MovieManagement.Services;
using System.Reflection.Metadata.Ecma335;

namespace MovieManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private MovieService _movieService;
        public MovieController(MovieService movieService) { _movieService = movieService; }

        [HttpGet("GetMovies")]
        public async Task<List<Movie>> GetMovies() { 
            return await  _movieService.GetMovies();
        }
    }
        
    
}
