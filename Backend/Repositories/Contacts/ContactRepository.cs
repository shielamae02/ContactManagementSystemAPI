using Backend.Data;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.Contacts
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _context;

        public ContactRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> AddContact(int userId,Contact newContact)
        {
            _context.Contacts.Add(newContact);
            await _context.SaveChangesAsync();
            return newContact.Id;
        }

        public async Task<bool> DeleteContact(int userId, int contactId)
        {
            var db = _context.Contacts;
            var contact = await db.FirstOrDefaultAsync(c => c.UserId == userId && c.Id == contactId);
            if (contact is null)
            {
                return false;
            }

            db.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Contact>> GetContacts(int userId)
        {
            return await _context.Contacts
                .Where(c => c.UserId == userId)
                .Include(c => c.ContactNumbers)
                .Include(c => c.Addresses)
                .ToListAsync();
        }

        public async Task<Contact?> GetContact(int userId, int contactId)
        {
            return await _context.Contacts
                .Where(c => c.UserId == userId)
                .Include(c => c.ContactNumbers)
                .Include(c => c.Addresses)
                .FirstOrDefaultAsync(c => c.Id == contactId);
        }

        public async Task<bool> UpdateContact(int userId, Contact updateContact)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == updateContact.Id);
            if (contact is null)
            {
                return false;
            }
            //_context.Entry(contact).State = EntityState.Modified;
            contact.FirstName = updateContact.FirstName;
            contact.LastName = updateContact.LastName;
            contact.EmailAddress = updateContact.EmailAddress;
            contact.UpdatedAt = updateContact.UpdatedAt;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
