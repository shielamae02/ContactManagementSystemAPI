using AutoMapper;
using Backend.Entities;
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

        public async Task<Contact> AddContact(int userId,AddContactDto newContact)
        {
            var contact = _mapper.Map<Contact>(newContact);
            contact.UserId = userId;
            contact.Id = await _contactRepository.AddContact(contact);
            return contact;
        }

        public async Task<bool> DeleteContact(int userId, int contactId)
        {
            return await _contactRepository.DeleteContact(userId, contactId);
        }

        public async Task<ContactDto> GetContact(int userId, int contactId)
        {
            var contact = await _contactRepository.GetContact(userId, contactId);
            return _mapper.Map<ContactDto>(contact);
        }

        public async Task<ICollection<ContactDto>> GetContacts(int userId)
        {
            var contacts = await _contactRepository.GetContacts(userId);
            return contacts.Select(c => _mapper.Map<ContactDto>(c)).ToList();
        }

        public async Task<ContactDto> UpdateContact(int userId, int contactId, UpdateContactDto updatedContact)
        {
            var dbContact = _mapper.Map<Contact>(updatedContact);
            dbContact.UserId = userId;
            dbContact.Id = contactId;

            var result = await _contactRepository.UpdateContact(dbContact);
            if (!result)
            {
                return null;
            }

            return _mapper.Map<ContactDto>(dbContact);
        }
    }
}
