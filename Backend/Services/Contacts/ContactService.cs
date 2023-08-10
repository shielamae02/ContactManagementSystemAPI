using AutoMapper;
using Backend.Entities;
using Backend.Exceptions;
using Backend.Models.Contacts;
using Backend.Repositories.Contacts;

namespace Backend.Services.Contacts
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<Contact> AddContact(int userId, AddContactDto newContact)
        {
            var contact = _mapper.Map<Contact>(newContact);
            contact.UserId = userId;
            contact.Id = await _contactRepository.AddContact(contact);
            return contact;
        }

        public async Task<bool> DeleteContact(int userId, int contactId)
        {
            var contact = await _contactRepository.DeleteContact(userId, contactId);
            if (!contact)
            {
                throw new ContactDeletionFailedException("An error occurred while attempting to delete the contact.");
            }
            return contact;
        }

        public async Task<ContactDto> GetContact(int userId, int contactId)
        {
            var contact = await _contactRepository.GetContact(userId, contactId);
            if (contact is null)
            {
                throw new ContactNotFoundException("Contact not found.");
            }
            return _mapper.Map<ContactDto>(contact);
        }

        public async Task<ICollection<ContactDto>> GetContacts(int userId)
        {
            var contacts = await _contactRepository.GetContacts(userId);
            if (contacts is null)
            {
                throw new ContactNotFoundException("No contacts found.");
            }
            return contacts.Select(c => _mapper.Map<ContactDto>(c)).ToList();
        }

        public async Task<ContactDto> UpdateContact(int userId, int contactId, UpdateContactDto updateContact)
        {
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

            return _mapper.Map<ContactDto>(dbContact);
        }
    }
}
