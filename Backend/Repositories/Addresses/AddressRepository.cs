using Backend.Data;
using Backend.Entities;
using Backend.Exceptions.Contacts;
using Backend.Repositories.Contacts;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.Addresses
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;
        private readonly IContactRepository _contactRepository;

        public AddressRepository(DataContext context, IContactRepository contactRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        }

        public async Task<int> AddAddress(int contactId, Address newAddress)
        {
            _context.Addresses.Add(newAddress);
            await _context.SaveChangesAsync();
            return newAddress.Id;
        }

        public async Task<bool> DeleteAddress(int userId, int contactId, int addressId)
        {
            var contact = await _contactRepository.GetContact(userId, contactId);
            if(contact is null)
            {
                throw new ContactNotFoundException("Contact not found.");
            }

            var db = _context.Addresses;
            var address = await db.FirstOrDefaultAsync(c => c.ContactId == contact.Id && c.Id == addressId);
            if (address is null)
            {
                return false;
            }
            db.Remove(address);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Address?> GetAddress(int userId, int contactId, int addressId)
        {
            var contact = await _contactRepository.GetContact(userId, contactId);
            if (contact is null)
            {
                throw new ContactNotFoundException("Contact not found.");
            }

            return await _context.Addresses.FirstOrDefaultAsync(c => c.ContactId == contact.Id && c.Id == addressId);
        }

        public async Task<ICollection<Address>> GetAddresses(int userId, int contactId)
        {
            var contact = await _contactRepository.GetContact(userId, contactId);
            if (contact is null)
            {
                throw new ContactNotFoundException("Contact not found.");
            }
            return await _context.Addresses.Where(c => c.ContactId == contact.Id).ToListAsync();
        }

        public async Task<bool> UpdateAddress(int contactId, Address updateAddress)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(c => c.Id == updateAddress.Id && c.ContactId == contactId);
            if(address is null)
            {
                return false;
            }

            address.ContactId = updateAddress.ContactId;
            address.Details = updateAddress.Details;
            address.Label = updateAddress.Label;
            address.UpdatedAt = updateAddress.UpdatedAt;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
