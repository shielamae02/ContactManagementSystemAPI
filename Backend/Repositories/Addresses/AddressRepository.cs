using Backend.Data;
using Backend.Entities;
using Backend.Repositories.Contacts;

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

        public Task<bool> DeleteAddress(int userId, int contactId, int addressId)
        {
            throw new NotImplementedException();
        }

        public Task<Address?> GetAddress(int userId, int contactId, int addressId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Address>> GetAddresses(int userId, int contactId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAddress(int contactId, Address updateAddress)
        {
            throw new NotImplementedException();
        }
    }
}
