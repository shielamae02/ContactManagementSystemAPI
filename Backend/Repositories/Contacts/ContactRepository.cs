using Backend.Data;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.Contacts
{
    /// <summary>
    /// Repository for managing contact data.
    /// </summary>
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactRepository"/> class.
        /// </summary>
        /// <param name="context">The data context.</param>
        public ContactRepository(DataContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<int> AddContact(Contact newContact)
        {
            _context.Contacts.Add(newContact);
            await _context.SaveChangesAsync();
            return newContact.Id;
        }


        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public async Task<ICollection<Contact>> GetContacts(int userId)
        {
            return await _context.Contacts
                .Where(c => c.UserId == userId)
                .Include(c => c.ContactNumbers)
                .Include(c => c.Addresses)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Contact?> GetContact(int userId, int contactId)
        {
            return await _context.Contacts
                .Where(c => c.UserId == userId)
                .Include(c => c.ContactNumbers)
                .Include(c => c.Addresses)
                .FirstOrDefaultAsync(c => c.Id == contactId);
        }


        /// <inheritdoc/>
        public async Task<bool> UpdateContact(int userId, Contact updateContact)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == updateContact.Id && c.UserId == userId);
            if (contact is null)
            {
                return false;
            }

            contact.UserId = updateContact.UserId;
            contact.FirstName = updateContact.FirstName;
            contact.LastName = updateContact.LastName;
            contact.EmailAddress = updateContact.EmailAddress;
            contact.UpdatedAt = updateContact.UpdatedAt;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
