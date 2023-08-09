using Backend.Entities;

namespace Backend.Repositories.Contacts
{
    public interface IContactRepository
    {
        Task<ICollection<Contact>> GetContacts(int userId);
        Task<Contact?> GetContact(int userId, int contactId);
        Task<int> AddContact(Contact newContact);
        Task<bool> UpdateContact(Contact updateContact);
        Task<bool> DeleteContact(int userId, int contactId);
    }
}
