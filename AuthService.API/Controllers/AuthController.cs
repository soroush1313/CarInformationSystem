using AuthService.API.Models;
using AuthService.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationRequest request)
        {
            var response = await _authService.RegisterUserAsync(request);
            if (!response.Success)
                return BadRequest(response.Message);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            var response = await _authService.AuthenticateUserAsync(request);
            if(!response.Success)
                return Unauthorized(response.Message);
            return Ok(response);
        }
    }
}
