using AutoMapper;
using Backend.Entities;
using Backend.Exceptions.ContactNumbers;
using Backend.Exceptions.Contacts;
using Backend.Models.ContactNumbers;
using Backend.Repositories.ContactNumbers;
using Backend.Repositories.Contacts;

namespace Backend.Services.ContactNumbers
{

    /// <summary>
    /// Service for managing contact number operations.
    /// </summary>
    public class ContactNumberService : IContactNumberService
    {
        private readonly IContactNumberRepository _contactNumberRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;


        /// <summary>
        /// Initializes a new instance of the <see cref="ContactNumberService"/> class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance.</param>
        /// <param name="contactNumberRepository">The contact number repository.</param>
        /// <param name="contactRepository">The contact repository.</param>
        public ContactNumberService(IMapper mapper, IContactNumberRepository contactNumberRepository, IContactRepository contactRepository)
        {
            _contactNumberRepository = contactNumberRepository ?? throw new ArgumentNullException(nameof(contactNumberRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        }

        /// <inheritdoc/>
        public async Task<ContactNumber> AddContactNumber(int userId, int contactId, AddContactNumberDto newContactNumber)
        {
            var contact = await _contactRepository.GetContact(userId, contactId);
            if (contact is null)
            {
                throw new ContactNotFoundException("Contact not found.");
            }

            var contactNumber = _mapper.Map<ContactNumber>(newContactNumber);
            contactNumber.ContactId = contact.Id;
            contactNumber.Id = await _contactNumberRepository.AddContactNumber(contactId, contactNumber);
            return contactNumber;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteContactNumber(int userId, int contactId, int contactNumberId)
        {
            var contactNumber = await _contactNumberRepository.DeleteContactNumber(userId, contactId, contactNumberId);
            if (!contactNumber)
            {
                throw new ContactNumberDeletionFailedException("An error occurred while attempting to delete the contact number.");
            }
            return contactNumber;
        }

        /// <inheritdoc/>
        public async Task<ContactNumberDto> GetContactNumber(int userId, int contactId, int contactNumberId)
        {
            var contactNumber = await _contactNumberRepository.GetContactNumber(userId, contactId, contactNumberId);
            if (contactNumber is null)
            {
                throw new ContactNumberNotFoundException("Contact number not found.");
            }
            return _mapper.Map<ContactNumberDto>(contactNumber);
        }

        /// <inheritdoc/>
        public async Task<ICollection<ContactNumberDto>> GetContactNumbers(int userId, int contactId)
        {
            var contactNumbers = await _contactNumberRepository.GetContactNumbers(userId, contactId);
            if (contactNumbers is null)
            {
                throw new ContactNumberNotFoundException("No contact numbers found.");
            }
            return contactNumbers.Select(c => _mapper.Map<ContactNumberDto>(c)).ToList();
        }

        /// <inheritdoc/>
        public async Task<ContactNumberDto> UpdateContactNumber(int userId, int contactId, int contactNumberId, UpdateContactNumberDto updateContactNumber)
        {
            var db = await _contactNumberRepository.GetContactNumber(userId, contactId, contactNumberId);
            if (db is null)
            {
                throw new ContactNumberNotFoundException($"Contact number with ID {contactId} not found.");
            }

            var dbContactNumber = _mapper.Map(updateContactNumber, db);
            dbContactNumber.Id = contactNumberId;
            dbContactNumber.ContactId = contactId;

            var result = await _contactNumberRepository.UpdateContactNumber(contactId, dbContactNumber);
            if (!result)
            {
                throw new ContactNumberUpdateFailedException("Contact number update failed.");
            }

            return _mapper.Map<ContactNumberDto>(dbContactNumber);
        }
    }
}
