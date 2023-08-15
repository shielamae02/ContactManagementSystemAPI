using Backend.Entities;
using Backend.Models.Addresses;

namespace Backend.Services.Addresses
{
    /// <summary>
    /// Provides methods to manage addresses for a user's contacts.
    /// </summary>
    public interface IAddressService
    {
        /// <summary>
        /// Adds a new address to the user's contact.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="contactId">The ID of the contact.</param>
        /// <param name="newAddress">The new address data transfer object to add.</param>
        /// <returns>The added address object.</returns>
        Task<Address> AddAddress(int userId, int contactId, AddAddressDto newAddress);

        /// <summary>
        /// Gets a collection of addresses for a specified contact belonging to a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="contactId">The ID of the contact.</param>
        /// <returns>A collection of address data transfer objects belonging to the contact.</returns>
        Task<ICollection<AddressDto>> GetAddresses(int userId, int contactId);

        /// <summary>
        /// Gets a specific address for the specified user, contact, and address ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="contactId">The ID of the contact.</param>
        /// <param name="addressId">The ID of the address.</param>
        /// <returns>Address data transfer object if found, otherwise null.</returns>
        Task<AddressDto> GetAddress(int userId, int contactId, int addressId);

        /// <summary>
        /// Deletes an address from the user's contact.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="contactId">The ID of the contact.</param>
        /// <param name="addressId">The ID of the address to delete.</param>
        /// <returns>True if deletion is successful, otherwise false.</returns>
        Task<bool> DeleteAddress(int userId, int contactId, int addressId);

        /// <summary>
        /// Updates an existing address in the system for the user's contact.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="contactId">The ID of the contact.</param>
        /// <param name="addressId">The ID of the address to update.</param>
        /// <param name="updateAddress">The updated address data transfer object.</param>
        /// <returns>Address data transfer object if update is successful, otherwise null.</returns>
        Task<AddressDto> UpdateAddress(int userId, int contactId, int addressId, UpdateAddressDto updateAddress);
    }
}
