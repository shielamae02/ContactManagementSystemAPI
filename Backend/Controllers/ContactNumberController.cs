using Backend.Entities;
using Backend.Exceptions;
using Backend.Models.ContactNumbers;
using Backend.Services.ContactNumbers;
using Backend.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/contacts/{contactId}/contactNumbers")]
    [Authorize]
    public class ContactNumberController : ControllerBase
    {

        private readonly IContactNumberService _contactNumberService;
        private readonly IUserService _userService;
        private readonly ILogger<ContactNumberController> _logger;

        public ContactNumberController(IContactNumberService contactNumberService, ILogger<ContactNumberController> logger, IUserService userService)
        {
            _contactNumberService = contactNumberService ?? throw new ArgumentNullException(nameof(contactNumberService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger ?? throw new ArgumentException(nameof(logger));
        }

        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetContactNumbers(int contactId)
        {
            try
            {
                var contactNumbers = await _contactNumberService.GetContactNumbers(contactId);
                if (contactNumbers is null)
                {
                    return NotFound("No contact numbers found.");
                }
                return Ok(contactNumbers);
            }
            catch (ContactNumberNotFoundException ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{contactNumberId}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetContactNumber(int contactId, int contactNumberId)
        {
            try
            {
                var contactNumber = await _contactNumberService.GetContactNumber(contactId, contactNumberId);
                if (contactNumber is null)
                {
                    return NotFound("Contact number not found.");
                }
                return Ok(contactNumber);
            }
            catch (ContactNumberNotFoundException ex)
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

        [HttpPost]
        public async Task<IActionResult> AddContactNumber(int contactId, [FromBody] AddContactNumberDto newContactNumber)
        {
            try
            {
                var userId = await _userService.GetUserId();
                var contactNumber = await _contactNumberService.AddContactNumber(userId, contactId, newContactNumber);
                if (contactNumber is null)
                {
                    return BadRequest("Contact number creation failed.");
                }
                return Ok(contactNumber);
            }
            catch (ContactNumberCreationFailedException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("{contactNumberId}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> DeleteContactNumber(int contactId, int contactNumberId)
        {
            try
            {
                var contact = await _contactNumberService.DeleteContactNumber(contactId, contactNumberId);
                if (!contact)
                {
                    return NotFound("Contact number not found.");
                }
                return Ok("Successfully deleted contact number.");
            }
            catch (ContactNumberDeletionFailedException ex)
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

        [HttpPut("{contactNumberId}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> UpdateContactNumber(int contactId, int contactNumberId, [FromBody] UpdateContactNumberDto updateContactNumber)
        {
            try
            {
                var contactNumber = await _contactNumberService.UpdateContactNumber(contactId, contactNumberId, updateContactNumber);
                return Ok(contactNumber);
            }
            catch (ContactNumberUpdateFailedException ex)
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
