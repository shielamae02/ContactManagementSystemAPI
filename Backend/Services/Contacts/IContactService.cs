using Backend.Entities;
using Backend.Models.Contacts;

namespace Backend.Services.Contacts
{
    public interface IContactService
    {
        Task<ContactDto> GetContact(int userId, int contactId);
        Task<Contact> AddContact(int userId, AddContactDto newContact);
        Task<IEnumerable<ContactDto>> GetContacts(int userId);
        Task<bool> DeleteContact(int userId, int contactId);
        Task<ContactDto> UpdateContact(int contactId, UpdateContactDto updateContact);
    }
}
