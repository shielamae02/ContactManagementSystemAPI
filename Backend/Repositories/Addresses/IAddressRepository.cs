using Backend.Entities;

namespace Backend.Repositories.Addresses
{
    public interface IAddressRepository
    {
        Task<int> AddAddress(int contactId, Address newAddress);
        Task<ICollection<Address>> GetAddresses(int userId, int contactId);
        Task<Address?> GetAddress(int userId, int contactId, int addressId);
        Task<bool> DeleteAddress(int userId, int contactId, int addressId);
        Task<bool> UpdateAddress(int contactId, Address updateAddress);
    }
}
