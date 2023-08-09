using Backend.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        private int _userId;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService ?? throw new Exception(nameof(userService));
            _logger = logger ?? throw new Exception(nameof(logger));
            UserIdentifier();

        }

        private async void UserIdentifier()
        {
            _userId = await _userService.GetUserId();
        }

        [HttpGet]
        public async Task<IActionResult> GetUserDetails()
        {
            try
            {
                var user = await _userService.GetUserId();
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Something went wrong.");

            }
        }

    }
}
