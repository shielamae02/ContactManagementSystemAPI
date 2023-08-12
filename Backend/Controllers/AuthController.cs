using Backend.Exceptions.Users;
using Backend.Models.Auths;
using Backend.Services.Auths;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace Backend.Controllers
{
    /// <summary>
    /// Controller for user authentication operations.
    /// </summary>
    [EnableCors(origins: "http://localhost:5173", headers: "*", methods: "*")]
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="authService">The service for user authentication.</param>
        /// <param name="logger">The logger instance for logging.</param>
        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        /// <summary>
        /// Logs in a user with the provided credentials.
        /// </summary>
        /// <param name="request">The login request containing user credentials.</param>
        /// <returns>An action result containing user information if successful, or an error response.</returns>
        [HttpPost("login")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(UserLoginDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
            catch (UserNotFoundException ex)
            {
                _logger.LogError(ex, "User not found.");
                return NotFound(ex.Message);
            }
            catch (UserAuthenticationFailedException ex)
            { 
                _logger.LogError(ex, "Incorrect password.");
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong.");
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Registers a new user with the provided registration data.
        /// </summary>
        /// <param name="request">The registration request containing user information.</param>
        /// <returns>An action result indicating the success or failure of the registration.</returns>
        [HttpPost("register")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(UserRegisterDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            try
            {
                var user = await _authService.AuthRegister(request);
                if (user is null)
                {
                    _logger.LogError("User registration failed.");
                    return BadRequest();
                }
                return StatusCode(201, user);
            }
            catch (UserAuthenticationFailedException ex)
            {
                _logger.LogError(ex, "User already exists.");
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong.");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
