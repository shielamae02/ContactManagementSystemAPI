using Backend.Entities;
using Backend.Exceptions.Users;
using Backend.Models.Auths;
using Backend.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    /// <summary>
    /// Controller for managing user-related operations.
    /// </summary>
    [ApiController]
    [Route("api/user")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        private int _userId;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">The service for user-related operations.</param>
        /// <param name="logger">The logger instance for logging.</param>
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

        /// <summary>
        /// Gets the details of the authenticated user.
        /// </summary>
        /// <returns>User details if found, or an error response.</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Deletes the authenticated user.
        /// </summary>
        /// <returns>A success message if the user is deleted, or an error response.</returns>
        [HttpDelete]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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


        /// <summary>
        /// Updates the details of the authenticated user.
        /// </summary>
        /// <param name="updateUser">The updated user information.</param>
        /// <returns>The updated user information if successful, or an error response.</returns>
        [HttpPut]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(UserRegisterDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
