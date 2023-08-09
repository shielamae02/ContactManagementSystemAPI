using Backend.Entities;

namespace Backend.Repositories.Contacts
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContacts(int userId);
        Task<Contact?> GetContact(int userId, int contactId);
        Task<int> AddContact(int userId, Contact newContact);
        Task<bool> UpdateContact(int userId, Contact updateContact);
        Task<bool> DeleteContact(int userId, int contactId);
    }
}
