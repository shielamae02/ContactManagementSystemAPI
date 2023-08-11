using Backend.Entities;
using Backend.Models.Addresses;

namespace Backend.Services.Addresses
{
    public interface IAddressService
    {
        Task<Address> AddAddress(int userId, int contactId, AddAddressDto newAddress);
        Task<ICollection<AddressDto>> GetAddresses(int userId, int contactId);
        Task<AddressDto> GetAddress(int userId, int contactId, int addressId);
        Task<bool> DeleteAddress(int userId, int contactId, int addressId);
        Task<AddressDto> UpdateAddress(int userId, int contactId, int addressId, UpdateAddressDto updateAddress);
    }
}
