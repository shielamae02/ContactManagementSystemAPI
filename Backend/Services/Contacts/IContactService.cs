using Backend.Entities;
using Backend.Models.Contacts;

namespace Backend.Services.Contacts
{
    public interface IContactService
    {
        Task<ContactDto> GetContact(int id);
        Task<Contact> AddContact(AddContactDto newContact);
        Task<IEnumerable<ContactDto>> GetContacts();
        Task<bool> DeleteContact(int id);
        Task<ContactDto> UpdateContact(int id, UpdateContactDto updateContact);
    }
}
