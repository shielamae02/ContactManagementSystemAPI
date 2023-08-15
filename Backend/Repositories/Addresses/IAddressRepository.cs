using Backend.Entities;

namespace Backend.Repositories.Addresses
{
    /// <summary>
    /// Provides methods to manage addresses for a user's contacts
    /// </summary>
    public interface IAddressRepository
    {
        /// <summary>
        /// Adds a new address to the user's contact.
        /// </summary>
        /// <param name="contactId">The ID of the contact.</param>
        /// <param name="newAddress">The new address to add.</param>
        /// <returns>The ID of the added address.</returns>
        Task<int> AddAddress(int contactId, Address newAddress);

        /// <summary>
        /// Gets a collection of addresses for a specified contact belonging to a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="contactId">The ID of the contact.</param>
        /// <returns>A collection of address objects belonging to the contact.</returns>
        Task<ICollection<Address>> GetAddresses(int userId, int contactId);

        /// <summary>
        /// Gets a specific address for the specified user and contact.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="contactId">The ID of the contact.</param>
        /// <param name="addressId">The ID of the address.</param>
        /// <returns>Address information if found, otherwise null.</returns>
        Task<Address?> GetAddress(int userId, int contactId, int addressId);

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
        /// <param name="contactId">The ID of the contact.</param>
        /// <param name="updateAddress">The updated address information.</param>
        /// <returns>True if update is successful, otherwise false.</returns>
        Task<bool> UpdateAddress(int contactId, Address updateAddress);
    }
}
