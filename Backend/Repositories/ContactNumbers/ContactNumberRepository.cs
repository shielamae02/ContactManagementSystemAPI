using Backend.Data;
using Backend.Entities;
using Backend.Exceptions.Contacts;
using Backend.Repositories.Contacts;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.ContactNumbers
{
    /// <summary>
    /// Repository for managing contact number data.
    /// </summary>
    public class ContactNumberRepository : IContactNumberRepository
    {
        private readonly DataContext _context;
        private readonly IContactRepository _contactRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactNumberRepository"/> class.
        /// </summary>
        /// <param name="context">The data context.</param>
        /// <param name="contactRepository">The contact repository.</param>
        public ContactNumberRepository(DataContext context, IContactRepository contactRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        }

        /// <inheritdoc/>
        public async Task<int> AddContactNumber(int contactId, ContactNumber newContactNumber)
        {
            _context.ContactNumbers.Add(newContactNumber);
            await _context.SaveChangesAsync();
            return newContactNumber.Id;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteContactNumber(int userId, int contactId, int contactNumberId)
        {
            var contact = await _contactRepository.GetContact(userId, contactId);
            if (contact is null)
            {
                throw new ContactNotFoundException("Contact not found.");
            }

            var db = _context.ContactNumbers;
            var contactNumber = await db.FirstOrDefaultAsync(c => c.ContactId == contact.Id && c.Id == contactNumberId);
            if (contactNumber is null)
            {
                return false;
            }

            db.Remove(contactNumber);
            await _context.SaveChangesAsync();
            return true;
        }


        /// <inheritdoc/>
        public async Task<ContactNumber?> GetContactNumber(int userId, int contactId, int contactNumberId)
        {
            var contact = await _contactRepository.GetContact(userId, contactId);
            if (contact is null)
            {
                throw new ContactNotFoundException("Contact not found.");
            }
            return await _context.ContactNumbers
                .FirstOrDefaultAsync(c => c.ContactId == contact.Id && c.Id == contactNumberId);
        }


        /// <inheritdoc/>
        public async Task<ICollection<ContactNumber>> GetContactNumbers(int userId,int contactId)
        {
            var contact = await _contactRepository.GetContact(userId, contactId);
            if (contact is null)
            {
                throw new ContactNotFoundException("Contact not found.");
            }
            return await _context.ContactNumbers.Where(c => c.ContactId == contact.Id).ToListAsync();
        }

        /// <inheritdoc/>
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
