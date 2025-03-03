using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Model;
using MovieManagement.Services;

namespace MovieManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(string username,string password)
        {
            var user = _userService.Authenticate(username, password);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(user);
        }

        [HttpPost("register")]
        public IActionResult Register(MovieUser model)
        {
            var success = _userService.Register(model.Username, model.Password, model.Email);
            if (success==null)
                return BadRequest(new { message = "Username already exists" });
            return Ok(success);
        }
    }
}
