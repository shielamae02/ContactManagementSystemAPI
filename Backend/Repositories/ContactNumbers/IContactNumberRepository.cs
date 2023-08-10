using Backend.Entities;

namespace Backend.Repositories.ContactNumbers
{
    public interface IContactNumberRepository
    {
        Task<ICollection<ContactNumber>> GetContactNumbers(int userId, int contactId);
        Task<ContactNumber?> GetContactNumber(int userId, int contactId, int contactNumberId);
        Task<int> AddContactNumber(int contactId, ContactNumber newContactNumber);
        Task<bool> DeleteContactNumber(int userId,int contactId, int contactNumberId);
        Task<bool> UpdateContactNumber(int contactId, ContactNumber updateContactNumber);
    }
}
