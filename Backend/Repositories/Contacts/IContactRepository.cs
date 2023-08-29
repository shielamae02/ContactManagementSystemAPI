using Backend.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Backend.Repositories.Contacts
{
    /// <summary>
    /// Provides methods to manage user contacts.
    /// </summary>
    public interface IContactRepository
    {
        /// <summary>
        /// Gets a collection of contacts for a specified user 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>A collection of contact objects belonging to a user</returns>
        Task<ICollection<Contact>> GetContacts(int userId);

        /// <summary>
        /// Gets a specific contact for the specified user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="contactId"></param>
        /// <returns>Contact information</returns>
        Task<Contact?> GetContact(int userId, int contactId);

        /// <summary>
        /// Adds a new contact to the user's contacts 
        /// </summary>
        /// <param name="newContact"></param>
        /// <returns>Contact Id</returns>
        Task<int> AddContact(Contact newContact);

        /// <summary>
        /// Updates an existing contact in the system with the provided user contact.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="updateContact"></param>
        /// <returns>A boolean indicating the success or failure of the update operation</returns>
        Task<bool> UpdateContact(int userId, Contact updateContact);

        /// <summary>
        /// Deletes a user from the system based on the provided user Id and contactId 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="contactId"></param>
        /// <returns>A boolean indicating the success or failure of the deletion operation.</returns>
        Task<bool> DeleteContact(int userId, int contactId);


        Task<bool> UpdateContactProperty(Contact contact, JsonPatchDocument<Contact> request);
    }
}
