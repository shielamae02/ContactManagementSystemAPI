namespace Backend.Repositories.Contacts
{
    public interface IContactRepository
    {
        Task<ICollection<Contact>> GetContacts();
        Task<Contact> GetContact(int id);
        Task<int> AddContact(Contact newContact);
        Task<bool> UpdateContact(Contact updateContact);
        Task<bool> DeleteContact(int id);
    }
}
