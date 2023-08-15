using Backend.Entities;

namespace Backend.Repositories.ContactNumbers
{
    /// <summary>
    /// Provides methods to manage contact numbers for a user's contacts.
    /// </summary>
    public interface IContactNumberRepository
    {
        /// <summary>
        /// Gets a collection of contact numbers for a specified contact belonging to a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="contactId">The ID of the contact.</param>
        /// <returns>A collection of contact number objects belonging to the contact.</returns>
        Task<ICollection<ContactNumber>> GetContactNumbers(int userId, int contactId);

        /// <summary>
        /// Gets a specific contact number for the specified user and contact.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="contactId">The ID of the contact.</param>
        /// <param name="contactNumberId">The ID of the contact number.</param>
        /// <returns>Contact number information if found, otherwise null.</returns>
        Task<ContactNumber?> GetContactNumber(int userId, int contactId, int contactNumberId);

        /// <summary>
        /// Adds a new contact number to the user's contact.
        /// </summary>
        /// <param name="contactId">The ID of the contact.</param>
        /// <param name="newContactNumber">The new contact number to add.</param>
        /// <returns>The ID of the added contact number.</returns>
        Task<int> AddContactNumber(int contactId, ContactNumber newContactNumber);

        /// <summary>
        /// Deletes a contact number from the user's contact.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="contactId">The ID of the contact.</param>
        /// <param name="contactNumberId">The ID of the contact number to delete.</param>
        /// <returns>True if deletion is successful, otherwise false.</returns>
        Task<bool> DeleteContactNumber(int userId,int contactId, int contactNumberId);

        /// <summary>
        /// Updates an existing contact number in the system for the user's contact.
        /// </summary>
        /// <param name="contactId">The ID of the contact.</param>
        /// <param name="updateContactNumber">The updated contact number information.</param>
        /// <returns>True if update is successful, otherwise false.</returns>
        Task<bool> UpdateContactNumber(int contactId, ContactNumber updateContactNumber);
    }
}
