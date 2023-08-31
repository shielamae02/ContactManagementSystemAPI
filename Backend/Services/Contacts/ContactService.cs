using AutoMapper;
using Backend.Entities;
using Backend.Exceptions.Contacts;
using Backend.Models.Contacts;
using Backend.Repositories.Contacts;
using Backend.Repositories.Users;
using Backend.Services.ContactAudits;

namespace Backend.Services.Contacts
{
    /// <summary>
    /// Service for managing contacts.
    /// </summary>
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IContactAuditService _contactAuditService;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactService"/> class.
        /// </summary>
        /// <param name="contactRepository">The contact repository.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        /// <param name="contactAuditService">The contact audit service.</param>
        /// <param name="userRepository">The user repository.</param>
        /// <exception cref="ArgumentNullException">Thrown when one of the parameters is null.</exception>
        public ContactService(IContactRepository contactRepository, IMapper mapper, IContactAuditService contactAuditService, IUserRepository userRepository)
        {
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _contactAuditService = contactAuditService ?? throw new ArgumentNullException(nameof(contactAuditService));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }


        /// <inheritdoc />
        public async Task<Contact> AddContact(int userId, AddContactDto newContact)
        {
            var user = await _userRepository.GetUserById(userId);
            var contact = _mapper.Map<Contact>(newContact);
            contact.UserId = userId;

            contact.Id = await _contactRepository.AddContact(contact);

            await _contactAuditService.AuditContact(
                user,
                $"User {user.FirstName} {user.LastName} added a contact.",
                "Create"
             );

            return contact;
        }

        /// <inheritdoc />
        public async Task<bool> DeleteContact(int userId, int contactId)
        {
            var user = await _userRepository.GetUserById(userId);
            var contact = await _contactRepository.DeleteContact(userId, contactId);
            if (!contact)
            {
                throw new ContactDeletionFailedException("An error occurred while attempting to delete the contact.");
            }

            await _contactAuditService.AuditContact(
               user,
               $"User {user.FirstName} {user.LastName} deleted a contact with Id {contactId}.",
               "Delete"
            );

            return contact;
        }

        /// <inheritdoc />
        public async Task<ContactDto> GetContact(int userId, int contactId)
        {
            var contact = await _contactRepository.GetContact(userId, contactId);
            if (contact is null)
            {
                throw new ContactNotFoundException("Contact not found.");
            }

            return _mapper.Map<ContactDto>(contact);
        }

        /// <inheritdoc />
        public async Task<ICollection<ContactDto>> GetContacts(int userId)
        {
            var contacts = await _contactRepository.GetContacts(userId);
            if (contacts is null)
            {
                throw new ContactNotFoundException("No contacts found.");
            }
            return contacts.Select(c => _mapper.Map<ContactDto>(c)).ToList();
        }

        /// <inheritdoc />
        public async Task<ContactDto> UpdateContact(int userId, int contactId, UpdateContactDto updateContact)
        {
            var user = await _userRepository.GetUserById(userId);
            var db = await _contactRepository.GetContact(userId, contactId);
            if (db is null)
            {
                throw new ContactNotFoundException($"Contact with ID {contactId} not found.");
            }

            var dbContact = _mapper.Map(updateContact, db);
            dbContact.Id = contactId;

            var result = await _contactRepository.UpdateContact(userId, dbContact);
            if (!result)
            {
                throw new ContactUpdateFailedException("Contact update failed.");
            }

            await _contactAuditService.AuditContact(
               user,
               $"User {user.FirstName} {user.LastName} updated a contact with Id {contactId}.",
               "Update"
            );

            return _mapper.Map<ContactDto>(dbContact);
        }
    }
}
