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

        public async Task<Contact> AddContact(AddContactDto newContact)
        {
            var contact = _mapper.Map<Contact>(newContact);
            contact.Id = await _contactRepository.AddContact(contact);
            return contact;
        }

        public async Task<bool> DeleteContact(int id)
        {
            return await _contactRepository.DeleteContact(id);
        }

        public async Task<ContactDto> GetContact(int id)
        {
            var contact = await _contactRepository.GetContact(id);
            return _mapper.Map<ContactDto>(contact);
        }

        public async Task<IEnumerable<ContactDto>> GetContacts()
        {
            var contacts = await _contactRepository.GetContacts();
            return contacts.Select(c => _mapper.Map<ContactDto>(c)).ToList();
        }

        public async Task<ContactDto> UpdateContact(int id, UpdateContactDto updatedContact)
        {
            var dbContact = _mapper.Map<Contact>(updatedContact);
            dbContact.Id = id;

            var result = await _contactRepository.UpdateContact(dbContact);
            if (!result)
            {
                return null;
            }

            return _mapper.Map<ContactDto>(dbContact);
        }
    }
}
