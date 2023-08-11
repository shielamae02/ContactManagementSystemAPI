using Backend.Entities;
using Backend.Exceptions.ContactNumbers;
using Backend.Models.ContactNumbers;
using Backend.Models.Contacts;
using Backend.Services.ContactNumbers;
using Backend.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Backend.Controllers
{
    /// <summary>
    /// Controller for managing contact numbers for a specific contact.
    /// </summary>
    [ApiController]
    [Route("api/contacts/{contactId}/contactNumbers")]
    [Authorize]
    public class ContactNumberController : ControllerBase
    {
        private readonly IContactNumberService _contactNumberService;
        private readonly IUserService _userService;
        private readonly ILogger<ContactNumberController> _logger;



        /// <summary>
        /// Initializes a new instance of the <see cref="ContactNumberController"/> class.
        /// </summary>
        /// <param name="contactNumberService">The service for managing contact numbers.</param>
        /// <param name="logger">The logger instance for logging.</param>
        /// <param name="userService">The service for user-related operations.</param>
        /// <exception cref="ArgumentNullException">Thrown when any of the parameters is null.</exception>
        public ContactNumberController(IContactNumberService contactNumberService, ILogger<ContactNumberController> logger, IUserService userService)
        {
            _contactNumberService = contactNumberService ?? throw new ArgumentNullException(nameof(contactNumberService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger ?? throw new ArgumentException(nameof(logger));
        }

        /// <summary>
        /// Gets all contact numbers for a specific contact.
        /// </summary>
        /// <param name="contactId">The ID of the contact.</param>
        /// <returns>A list of contact numbers if found, or an error response.</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<ContactNumberDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetContactNumbers(int contactId)
        {
            try
            {
                var userId = await _userService.GetUserId();
                var contactNumbers = await _contactNumberService.GetContactNumbers(userId, contactId);
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

        /// <summary>
        /// Gets a specific contact number for a specific contact.
        /// </summary>
        /// <param name="contactId">The ID of the contact.</param>
        /// <param name="contactNumberId">The ID of the contact number to retrieve.</param>
        /// <returns>The contact number if found, or an error response.</returns>
        [HttpGet("{contactNumberId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<ContactNumberDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetContactNumber(int contactId, int contactNumberId)
        {
            try
            {
                var userId = await _userService.GetUserId();
                var contactNumber = await _contactNumberService.GetContactNumber(userId, contactId, contactNumberId);
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


        /// <summary>
        /// Adds a new contact number for a specific contact.
        /// </summary>
        /// <param name="contactId">The ID of the contact.</param>
        /// <param name="newContactNumber">The contact number to add.</param>
        /// <returns>The added contact number if successful, or an error response.</returns>
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(ContactNumberDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
                return StatusCode(201, contactNumber);
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

        /// <summary>
        /// Deletes a specific contact number for a specific contact.
        /// </summary>
        /// <param name="contactId">The ID of the contact.</param>
        /// <param name="contactNumberId">The ID of the contact number to delete.</param>
        /// <returns>A success message if the contact number is deleted, or an error response.</returns>
        [HttpDelete("{contactNumberId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteContactNumber(int contactId, int contactNumberId)
        {
            try
            {
                var userId = await _userService.GetUserId();
                var contact = await _contactNumberService.DeleteContactNumber(userId, contactId, contactNumberId);
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


        /// <summary>
        /// Updates a specific contact number for a specific contact.
        /// </summary>
        /// <param name="contactId">The ID of the contact.</param>
        /// <param name="contactNumberId">The ID of the contact number to update.</param>
        /// <param name="updateContactNumber">The updated contact number information.</param>
        /// <returns>The updated contact number if successful, or an error response.</returns
        [HttpPut("{contactNumberId}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(ContactNumberDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateContactNumber(int contactId, int contactNumberId, [FromBody] UpdateContactNumberDto updateContactNumber)
        {
            try
            {
                var userId = await _userService.GetUserId();
                var contactNumber = await _contactNumberService.UpdateContactNumber(userId, contactId, contactNumberId, updateContactNumber);
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
