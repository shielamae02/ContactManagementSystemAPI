﻿using Backend.Exceptions;
using Backend.Models.Contacts;
using Backend.Services.Contacts;
using Backend.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    [Authorize]
   
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IUserService _userService;
        private readonly ILogger<ContactController> _logger;
        public ContactController(IContactService contactService, ILogger<ContactController> logger, IUserService userService)
        {
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }


        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            try
            {
                var userId = await _userService.GetUserId();
                var contacts = await _contactService.GetContacts(userId);
                if (contacts is null)
                    return NotFound("No contacts found.");
                return Ok(contacts);
            }
            catch (ContactNotFoundException ex)
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

        [HttpGet("{contactId}")]
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
        public async Task<IActionResult> AddContact(AddContactDto newContact)
        {
            try
            {
                var userId = await _userService.GetUserId();
                var contact = await _contactService.AddContact(userId, newContact);
                return Ok(contact);
            }
            catch (ContactNumberCreationFailedException ex)
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

        [HttpDelete("{contactId}")]
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
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpPut("{contactId}")]
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
