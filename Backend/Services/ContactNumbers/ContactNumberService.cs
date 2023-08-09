using AutoMapper;
using Backend.Entities;
using Backend.Exceptions;
using Backend.Models.ContactNumbers;
using Backend.Repositories.ContactNumbers;

namespace Backend.Services.ContactNumbers
{
    public class ContactNumberService : IContactNumberService
    {
        private readonly IContactNumberRepository _contactNumberRepository;
        private readonly IMapper _mapper;

        public ContactNumberService(IMapper mapper, IContactNumberRepository contactNumberRepository, ILogger<ContactNumberService> logger)
        {
            _contactNumberRepository = contactNumberRepository ?? throw new ArgumentNullException(nameof(contactNumberRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ContactNumber> AddContactNumber(int contactId, AddContactNumberDto newContactNumber)
        {
            var contactNumber = _mapper.Map<ContactNumber>(newContactNumber);
            contactNumber.ContactId = contactId;
            contactNumber.Id = await _contactNumberRepository.AddContactNumber(contactNumber);
            return contactNumber;
        }

        public async Task<bool> DeleteContactNumber(int contactId, int contactNumberId)
        {
            return await _contactNumberRepository.DeleteContactNumber(contactId, contactNumberId);
        }

        public async Task<ContactNumberDto> GetContactNumber(int contactId, int contactNumberId)
        {
            var contactNumber = await _contactNumberRepository.GetContactNumber(contactId, contactNumberId);
            return _mapper.Map<ContactNumberDto>(contactNumber);
        }

        public async Task<ICollection<ContactNumberDto>> GetContactNumbers(int contactId)
        {
            var contactNumbers = await _contactNumberRepository.GetContactNumbers(contactId);
            if (contactNumbers is null)
            {
                return null;
            }
            return contactNumbers.Select(c => _mapper.Map<ContactNumberDto>(c)).ToList();
        }

        public async Task<ContactNumberDto> UpdateContactNumber(int contactId, int contactNumberId, UpdateContactNumberDto updateContactNumber)
        {
            var dbContactNumber = _mapper.Map<ContactNumber>(updateContactNumber);
            dbContactNumber.Id = contactNumberId;
            dbContactNumber.ContactId = contactId;

            var result = await _contactNumberRepository.UpdateContactNumber(dbContactNumber);
            if (!result)
            {
                throw new UserUpdateFailedException("Contact number update failed.Something went wrong while updating the contact number.");
            }

            return _mapper.Map<ContactNumberDto>(dbContactNumber);
        }
    }
}
