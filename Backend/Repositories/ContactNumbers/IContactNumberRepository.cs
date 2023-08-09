using Backend.Entities;

namespace Backend.Repositories.ContactNumbers
{
    public interface IContactNumberRepository
    {
        Task<ICollection<ContactNumber>> GetContactNumbers(int contactId);
        Task<ContactNumber?> GetContactNumber(int contactId, int contactNumberId);
        Task<int> AddContactNumber(int contactId, ContactNumber newContactNumber);
        Task<bool> DeleteContactNumber(int contactId, int contactNumberId);
        Task<bool> UpdateContactNumber(ContactNumber updateContactNumber);
    }
}
