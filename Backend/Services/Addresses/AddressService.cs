using AutoMapper;
using Backend.Entities;
using Backend.Exceptions.Addresses;
using Backend.Exceptions.Contacts;
using Backend.Models.Addresses;
using Backend.Repositories.Addresses;
using Backend.Repositories.Contacts;

namespace Backend.Services.Addresses
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IContactRepository contactRepository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _addressRepository = addressRepository ?? throw new ArgumentNullException(nameof(mapper));
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Address> AddAddress(int userId, int contactId, AddAddressDto newAddress)
        {
            var contact = await _contactRepository.GetContact(userId, contactId);
            if(contact is null)
            {
                throw new ContactNotFoundException("Contact not found.");
            }

            var address = _mapper.Map<Address>(newAddress);
            address.ContactId = contact.Id;
            address.Id = await _addressRepository.AddAddress(contactId, address);
            return address;
        }

        public async Task<bool> DeleteAddress(int userId, int contactId, int addressId)
        {
            var address = await _addressRepository.DeleteAddress(userId, contactId, addressId);
            if (!address)
            {
                throw new AddressDeletionFailedException("An error occurred while attempting to delete the address.");
            }
            return address;
        }

        public async Task<AddressDto> GetAddress(int userId, int contactId, int addressId)
        {
            var address = await _addressRepository.GetAddress(userId, contactId, addressId);
            if(address is null)
            {
                throw new AddressNotFoundException("Address not found.");
            }

            return _mapper.Map<AddressDto>(address);
        }

        public async Task<ICollection<AddressDto>> GetAddresses(int userId, int contactId)
        {
            var addresses = await _addressRepository.GetAddresses(userId, contactId);
            if(addresses is null)
            {
                throw new AddressNotFoundException("No addresses found.");
            }

            return addresses.Select(c => _mapper.Map<AddressDto>(c)).ToList();
        }

        public async Task<AddressDto> UpdateAddress(int userId, int contactId, int addressId, UpdateAddressDto updateAddress)
        {
            var db = await _addressRepository.GetAddress(userId, contactId, addressId);
            if(db is null)
            {
                throw new AddressNotFoundException($"Address with ID {contactId} not found.");
            }

            var dbAddress = _mapper.Map(updateAddress, db);
            dbAddress.Id = addressId;
            dbAddress.ContactId = contactId;

            var result = await _addressRepository.UpdateAddress(contactId, dbAddress);
            if(!result)
            {
                throw new AddressUpdateFailedException("Address update failed.");
            }

            return _mapper.Map<AddressDto>(dbAddress);
        }
    }
}
