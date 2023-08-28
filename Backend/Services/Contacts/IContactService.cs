using Azure;
using Backend.Entities;
using Backend.Models.Contacts;
using Microsoft.AspNetCore.JsonPatch;

namespace Backend.Services.Contacts
{
    /// <summary>
    /// Provides methods to manage contacts for a user.
    /// </summary>
    public interface IContactService
    {
        /// <summary>
        /// Gets a specific contact for the specified user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="contactId">The ID of the contact.</param>
        /// <returns>Contact data transfer object if found, otherwise null.</returns>
        Task<ContactDto> GetContact(int userId, int contactId);

        /// <summary>
        /// Adds a new contact to the user's contacts.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="newContact">The new contact data transfer object to add.</param>
        /// <returns>The added contact object.</returns>
        Task<Contact> AddContact(int userId, AddContactDto newContact);


        /// <summary>
        /// Gets a collection of contacts for a specified user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A collection of contact data transfer objects belonging to the user.</returns>
        Task<ICollection<ContactDto>> GetContacts(int userId);


        /// <summary>
        /// Deletes a contact from the system based on the provided user ID and contact ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="contactId">The ID of the contact to delete.</param>
        /// <returns>True if deletion is successful, otherwise false.</returns>
        Task<bool> DeleteContact(int userId, int contactId);

        /// <summary>
        /// Updates an existing contact in the system with the provided user ID and contact information.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="contactId">The ID of the contact to update.</param>
        /// <param name="updateContact">The updated contact data transfer object.</param>
        /// <returns>Contact data transfer object if update is successful, otherwise null.</returns>
        Task<ContactDto> UpdateContact(int userId, int contactId, UpdateContactDto updateContact);

        Task<bool> UpdateUserContactProperty(User user, int contactId, JsonPatchDocument<Contact> request);
    }
}
