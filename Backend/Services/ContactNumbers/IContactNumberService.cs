using Backend.Entities;
using Backend.Models.ContactNumbers;

namespace Backend.Services.ContactNumbers
{
    public interface IContactNumberService
    {
        Task<ICollection<ContactNumberDto>> GetContactNumbers(int contactId);
        Task<ContactNumberDto> GetContactNumber(int contactId, int contactNumberId);
        Task<ContactNumber> AddContactNumber(int userId, int contactId, AddContactNumberDto newContactNumber);
        Task<bool> DeleteContactNumber(int contactId, int contactNumberId);
        Task<ContactNumberDto> UpdateContactNumber(int contactId, int contactNumberId, UpdateContactNumberDto updateContactNumber);
    }
}
