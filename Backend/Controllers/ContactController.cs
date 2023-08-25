﻿using Backend.Data;
using Backend.Exceptions.ContactNumbers;
using Backend.Exceptions.Contacts;
using Backend.Models.Contacts;
using Backend.Services.Contacts;
using Backend.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    /// <summary>
    /// Controller for managing contacts of an authenticated user.
    /// </summary>
    [ApiController]
    [Route("api/contacts")]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IContactService _contactService;
        private readonly IUserService _userService;
        private readonly ILogger<ContactController> _logger;


        /// <summary>
        /// Initializes a new instance of the <see cref="ContactController"/> class.
        /// </summary>
        /// <param name="contactService">The service for managing contacts.</param>
        /// <param name="logger">The logger instance for logging.</param>
        /// <param name="userService">The service for user-related operations.</param>
        public ContactController(IContactService contactService, ILogger<ContactController> logger, IUserService userService, DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        /// <summary>
        /// Gets all contacts for the authenticated user.
        /// </summary>
        /// <returns>A list of contacts belonging to the user.</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<ContactDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetContacts()
        {
            try
            {
                var userId = await _userService.GetUserId();
                var contacts = await _contactService.GetContacts(userId);
                if (contacts is null)
                {
                    return NotFound("No contacts found.");
                }
                return Ok(contacts);
            }
            catch (ContactNotFoundException ex)
            {
                _logger.LogError(ex, "Contact not found.");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong.");
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Gets a specific contact for the authenticated user.
        /// </summary>
        /// <param name="contactId">The ID of the contact to retrieve.</param>
        /// <returns>The contact information if found, or an error response.</returns>
        [HttpGet("{contactId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ContactDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetContact(int contactId)
        {
            try
            {
                var userId = await _userService.GetUserId();
                var contact = await _contactService.GetContact(userId, contactId);
                if (contact is null)
                {
                    return NotFound("Contact not found.");
                }
                return Ok(contact);
            }
            catch (ContactNotFoundException ex)
            {
                _logger.LogError(ex, "Contact not found.");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong.");
                return StatusCode(500, "Something went wrong.");
            }

        }


        /// <summary>
        /// Adds a new contact for the authenticated user.
        /// </summary>
        /// <param name="newContact">The contact information to add.</param>
        /// <returns>The added contact if successful, or an error response.</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST /api/contacts
        ///     {
        ///         "firstName": "Rosa",
        ///         "lastName": "Diaz",
        ///         "emailAddress": "rosadiaz@example.com",
        ///         "createdAt": "2023-08-15T02:17:55.868Z",
        ///         "contactNumbers": [
        ///         {
        ///             "id": 0,
        ///             "contactId": 0,
        ///             "number": "0912345789",
        ///             "label": "Globe",
        ///             "createdAt": "2023-08-15T02:17:55.868Z",
        ///             "updatedAt": "2023-08-15T02:17:55.868Z"
        ///         }
        ///         ],
        ///         addresses": [
        ///         {
        ///             "id": 0,
        ///             "contactId": 0,
        ///             "details": "Cebu City",
        ///             "label": "Home",
        ///             "createdAt": "2023-08-15T02:17:55.868Z",
        ///             "updatedAt": "2023-08-15T02:17:55.868Z"
        ///             }
        ///         ]
        ///     }
        /// </remarks>
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(ContactDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddContact(AddContactDto newContact)
        {
            try
            {
                var userId = await _userService.GetUserId();
                var contact = await _contactService.AddContact(userId, newContact);
                if (contact is null)
                {
                    throw new ContactCreationFailedException("User creation failed.");
                }
                return StatusCode(201, contact);
            }
            catch (ContactNumberCreationFailedException ex)
            {
                _logger.LogError(ex, "User creation failed.");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong.");
                return StatusCode(500, "Something went wrong.");
            }
        }


        /// <summary>
        /// Deletes a specific contact for the authenticated user.
        /// </summary>
        /// <param name="contactId">The ID of the contact to delete.</param>
        /// <returns>A success message if the contact is deleted, or an error response.</returns>
        [HttpDelete("{contactId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteContact(int contactId)
        {
            try
            {
                var userId = await _userService.GetUserId();
                var contact = await _contactService.DeleteContact(userId, contactId);
                if (!contact)
                {
                    return NotFound("Contact not found.");
                }
                return Ok("Successfully deleted contact.");
            }
            catch (ContactDeletionFailedException ex)
            {
                _logger.LogError(ex, "An error occurred while attempting to delete the contact.");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong.");
                return StatusCode(500, "Something went wrong.");
            }
        }

        /// <summary>
        /// Updates a specific contact for the authenticated user.
        /// </summary>
        /// <param name="contactId">The ID of the contact to update.</param>
        /// <param name="updatedContact">The updated contact information.</param>
        ///  /// <remarks>
        /// Sample Request:
        /// 
        ///     PUT /api/contacts/{contactId}
        ///     {
        ///         "firstName": "Rose",
        ///         "lastName": "Diaz",
        ///         "emailAddress": "rosie@example.com"
        ///     }
        /// </remarks>
        /// <returns>The updated contact information if successful, or an error response.</returns>

        [HttpPut("{contactId}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(ContactDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateContact(int contactId, UpdateContactDto updatedContact)
        {
            try
            {
                var userId = await _userService.GetUserId();
                var contact = await _contactService.UpdateContact(userId, contactId, updatedContact);
                return Ok(contact);
            }
            catch (ContactUpdateFailedException ex)
            {
                _logger.LogError(ex, "Contact update failed.");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong.");
                return StatusCode(500, "Something went wrong.");
            }
        }




    }
}
