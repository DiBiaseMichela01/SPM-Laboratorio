using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SPM.Tourism.Api.Services;
using SPM.Tourism.Api.DTOs;


namespace SPM.Tourism.Api.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController:ControllerBase
    {
        private readonly AuthService _authService;
        private readonly JwtTokenService _jwtTokenService;

        public AuthController(
            AuthService authService,
            JwtTokenService jwtTokenService)
        {
            _authService = authService;
            _jwtTokenService = jwtTokenService;
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
            var user = await _authService.LoginAsync(request);

            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            // Generate a JWT for the authenticated user
            string token = _jwtTokenService.GenerateToken(user);

            return Ok(new { token = token });
        }

        // Protected endpoint for testing JWT authentication
        [Authorize]
        [HttpGet("me")]
        public IActionResult GetCurrentUser()
        {
            return Ok("Authenticated access granted.");
        }
    }
    
}
