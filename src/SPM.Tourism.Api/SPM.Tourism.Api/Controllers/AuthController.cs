using Microsoft.AspNetCore.Mvc;
using SPM.Tourism.Api.Services;
using SPM.Tourism.Api.DTOs;

namespace SPM.Tourism.Api.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController:ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            bool success = await _authService.RegisterAsync(request);
            if (!success)
            {
                return Conflict("Email already registered.");
            }
            return Ok("User registered successfully.");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            bool validCredentials = await _authService.LoginAsync(request);

            if (!validCredentials)
            {
                return Unauthorized("Invalid email or password.");
            }

            return Ok("Credentials verified successfully.");
        }
    }
    
}
