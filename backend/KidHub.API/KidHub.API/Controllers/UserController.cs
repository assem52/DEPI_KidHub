using KidHub.Domain.Dtos;
using KidHub.Data.Entities;
using KidHub.Domain.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace KidHub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto dto)
        {
            try
            {
                var user = await _userService.RegisterAsync(dto);
                return Ok(new { message = "User created successfully.", user = user });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            try
            {
                var user = await _userService.LoginAsync(dto);
                return Ok(new { message = "Login successful.", user = user });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
        // Get a user by email
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
