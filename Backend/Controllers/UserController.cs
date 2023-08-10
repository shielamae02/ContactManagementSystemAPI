using Backend.Exceptions;
using Backend.Models.Auths;
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
                var user = await _userService.GetUserById(_userId);
                if(user is null)
                {
                    return NotFound("User details not found.");
                }
                return Ok(user);
            }
            catch(UserNotFoundException ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Something went wrong.");

            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser()
        {
            try
            {
                var user = await _userService.DeleteUser(_userId);
                if (!user)
                {
                    return NotFound("User not found.");
                }
                return Ok("Successfully deleted user.");
            }
            catch(UserDeletionFailedException ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserRegisterDto updateUser)
        {
            try
            {
                var user = await _userService.UpdateUser(_userId, updateUser);
                if (user is null)
                {
                    throw new UserUpdateFailedException("User update failed.");
                }
                return Ok(user);
            }
            catch (UserUpdateFailedException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Something went wrong.");
            }
        }

    }
}
