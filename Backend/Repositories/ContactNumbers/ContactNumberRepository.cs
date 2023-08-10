using Backend.Data;
using Backend.Entities;
using Backend.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.ContactNumbers
{
    public class ContactNumberRepository : IContactNumberRepository
    {
        private readonly DataContext _context;
        public ContactNumberRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> AddContactNumber(int contactId, ContactNumber newContactNumber)
        {
            _context.ContactNumbers.Add(newContactNumber);
            await _context.SaveChangesAsync();
            return newContactNumber.Id;
        }

        public async Task<bool> DeleteContactNumber(int contactId, int contactNumberId)
        {
            var db = _context.ContactNumbers;
            var contactNumber = await db.FirstOrDefaultAsync(c => c.ContactId == contactId && c.Id == contactNumberId);
            if (contactNumber is null)
            {
                return false;
            }

            db.Remove(contactNumber);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ContactNumber?> GetContactNumber(int contactId, int contactNumberId)
        {
            return await _context.ContactNumbers
                .FirstOrDefaultAsync(c => c.ContactId == contactId && c.Id == contactNumberId);
        }

        public async Task<ICollection<ContactNumber>> GetContactNumbers(int contactId)
        {
            return await _context.ContactNumbers.Where(c => c.ContactId == contactId).ToListAsync();
        }

        public async Task<bool> UpdateContactNumber(int contactId, ContactNumber updateContactNumber)
        {
            var contactNumber = await _context.ContactNumbers.FirstOrDefaultAsync(c => c.Id == updateContactNumber.Id && c.ContactId == contactId);
            if (contactNumber is null)
            {
                return false;
            }

            contactNumber.ContactId = updateContactNumber.ContactId;
            contactNumber.Number = updateContactNumber.Number;
            contactNumber.Label = updateContactNumber.Label;
            contactNumber.UpdatedAt = updateContactNumber.UpdatedAt;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
