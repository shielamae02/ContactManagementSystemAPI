using Backend.Entities;
using Backend.Models.ContactNumbers;

namespace Backend.Services.ContactNumbers
{
    /// <summary>
    /// Provides methods to manage contact numbers for a user's contacts.
    /// </summary>s
    public interface IContactNumberService
    {
        /// <summary>
        /// Gets a collection of contact numbers for a specified contact belonging to a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="contactId">The ID of the contact.</param>
        /// <returns>A collection of contact number data transfer objects belonging to the contact.</returns>
        Task<ICollection<ContactNumberDto>> GetContactNumbers(int userId,int contactId);

        /// <summary>
        /// Gets a specific contact number for the specified user and contact.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="contactId">The ID of the contact.</param>
        /// <param name="contactNumberId">The ID of the contact number.</param>
        /// <returns>Contact number data transfer object if found, otherwise null.</returns>
        Task<ContactNumberDto> GetContactNumber(int userId, int contactId, int contactNumberId);

        /// <summary>
        /// Adds a new contact number to the user's contact.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="contactId">The ID of the contact.</param>
        /// <param name="newContactNumber">The new contact number data transfer object to add.</param>
        /// <returns>The added contact number.</returns>
        Task<ContactNumber> AddContactNumber(int userId, int contactId, AddContactNumberDto newContactNumber);

        /// <summary>
        /// Deletes a contact number from the user's contact.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="contactId">The ID of the contact.</param>
        /// <param name="contactNumberId">The ID of the contact number to delete.</param>
        /// <returns>True if deletion is successful, otherwise false.</returns>
        Task<bool> DeleteContactNumber(int userId, int contactId, int contactNumberId);

        /// <summary>
        /// Updates an existing contact number in the system for the user's contact.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="contactId">The ID of the contact.</param>
        /// <param name="contactNumberId">The ID of the contact number to update.</param>
        /// <param name="updateContactNumber">The updated contact number data transfer object.</param>
        /// <returns>Contact number data transfer object if update is successful, otherwise null.</returns>
        Task<ContactNumberDto> UpdateContactNumber(int userId, int contactId, int contactNumberId, UpdateContactNumberDto updateContactNumber);
    }
}
