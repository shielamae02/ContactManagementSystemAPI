using Backend.Entities;
using Backend.Models.Contacts;

namespace Backend.Services.Contacts
{
    public interface IContactService
    {
        /// <summary>
        /// Gets a specific contact for the specified user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="contactId"></param>
        /// <returns>Contact information</returns>
        Task<ContactDto> GetContact(int userId, int contactId);

        /// <summary>
        /// Adds a new contact to the user's contacts 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newContact"></param>
        /// <returns>Contact object</returns>
        Task<Contact> AddContact(int userId, AddContactDto newContact);


        /// <summary>
        /// Gets a collection of contacts for a specified user 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>A collection of contact objects belonging to a user</returns>
        Task<ICollection<ContactDto>> GetContacts(int userId);


        /// <summary>
        /// Deletes a user from the system based on the provided user Id and contactId 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="contactId"></param>
        /// <returns>A boolean indicating the success or failure of the deletion operation</returns>
        Task<bool> DeleteContact(int userId, int contactId);

        /// <summary>
        /// Updates an existing contact in the system with the provided user contact
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="contactId"></param>
        /// <param name="updateContact"></param>
        /// <returns>Contact information</returns>
        Task<ContactDto> UpdateContact(int userId, int contactId, UpdateContactDto updateContact);
    }
}
