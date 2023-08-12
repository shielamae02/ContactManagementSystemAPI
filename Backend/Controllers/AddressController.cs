using Backend.Exceptions.Addresses;
using Backend.Exceptions.Contacts;
using Backend.Models.Addresses;
using Backend.Services.Addresses;
using Backend.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/contacts/{contactId}/address")]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;

        public AddressController(ILogger<AddressController> logger, IAddressService addressService, IUserService userService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _addressService = addressService ?? throw new ArgumentNullException(nameof(addressService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> AddAddress(int contactId, [FromBody] AddAddressDto newAddress)
        {
            try
            {
                var userId = await _userService.GetUserId();
                var address = await _addressService.AddAddress(userId, contactId, newAddress);
                if (address is null)
                {
                    throw new AddressCreationFailedException("Address creation failed.");
                }
                return StatusCode(201, address);
            }
            catch (ContactNotFoundException ex)
            {
                _logger.LogError(ex, "Contact not found.");
                return NotFound(ex.Message);
            }
            catch (AddressCreationFailedException ex)
            {
                _logger.LogError(ex, "Address creation failed.");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAddresses(int contactId)
        {
            try
            {
                var userId = await _userService.GetUserId();
                var addresses = await _addressService.GetAddresses(userId, contactId);
                if (addresses is null)
                {
                    return NotFound("No addresses found.");
                }
                return Ok(addresses);
            }
            catch (ContactNotFoundException ex)
            {
                _logger.LogError(ex, "Contact not found.");
                return NotFound(ex.Message);
            }
            catch (AddressNotFoundException ex)
            {
                _logger.LogError(ex, "No addresses found.");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong.");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{addressId}")]
        public async Task<IActionResult> GetAddress(int contactId, int addressId)
        {
            try
            {
                var userId = await _userService.GetUserId();
                var address = await _addressService.GetAddress(userId, contactId, addressId);
                if (address is null)
                {
                    return NotFound("Address not found.");
                }
                return Ok(address);
            }
            catch (ContactNotFoundException ex)
            {
                _logger.LogError(ex, "Contact not found.");
                return NotFound(ex.Message);
            }
            catch (AddressNotFoundException ex)
            {
                _logger.LogError(ex, "Address not found.");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong.");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{addressId}")]
        public async Task<IActionResult> DeleteAddress(int contactId, int addressId)
        {
            try
            {
                var userId = await _userService.GetUserId();
                var address = await _addressService.DeleteAddress(userId, contactId, addressId);
                if (!address)
                {
                    return NotFound("No addresses found.");
                }
                return Ok("Sucessfully deleted address.");
            }
            catch (ContactNotFoundException ex)
            {
                _logger.LogError(ex, "Contact not found.");
                return NotFound(ex.Message);
            }
            catch (AddressNotFoundException ex)
            {
                _logger.LogError(ex, "Address not found.");
                return NotFound(ex.Message);
            }
            catch (AddressDeletionFailedException ex)
            {
                _logger.LogError(ex, "An error occurred while attempting to delete the address.");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong.");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{addressId}")]
        public async Task<IActionResult> UpdateAddress(int contactId, int addressId, [FromBody] UpdateAddressDto updateAddress)
        {
            try
            {
                var userId = await _userService.GetUserId();
                var address = await _addressService.UpdateAddress(userId, contactId, addressId, updateAddress);
                return Ok(address);
            }
            catch (AddressNotFoundException ex)
            {
                _logger.LogError(ex, "Address not found.");
                return NotFound(ex.Message);
            }
            catch (AddressUpdateFailedException ex)
            {
                _logger.LogError(ex, "Address update failed.");
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
