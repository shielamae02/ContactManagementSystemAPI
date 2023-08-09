using Backend.Entities;
using Backend.Models.Contacts;

namespace Backend.Services.Contacts
{
    public interface IContactService
    {
        Task<ContactDto> GetContact(int userId, int contactId);
        Task<Contact> AddContact(int userId, AddContactDto newContact);
        Task<ICollection<ContactDto>> GetContacts(int userId);
        Task<bool> DeleteContact(int userId, int contactId);
        Task<ContactDto> UpdateContact(int userId, int contactId, UpdateContactDto updateContact);
    }
}
