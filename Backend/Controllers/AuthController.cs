using Backend.Exceptions;
using Backend.Models.Auths;
using Backend.Services.Auths;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;
        public AuthController(IAuthService authService, ILogger<AuthController> logger )
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            try
            {
                var user = await _authService.AuthLogin(request);
                if (user is null)
                {
                    throw new UserNotFoundException("User not found.");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured during user authentication: {ex.Message}", ex.Message);
                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            try
            {
                var user = await _authService.AuthRegister(request);
                if (user is null)
                {
                    _logger.LogError("Registration failed.");
                    return BadRequest();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured during user authentication: {ex.Message}", ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
