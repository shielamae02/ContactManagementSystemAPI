using AutoMapper;
using Backend.Entities;
using Backend.Models.Contacts;

namespace Backend.Mapper
{
    public class ContactMapper : Profile
    {
        public ContactMapper()
        {
            CreateMap<Contact, ContactDto>();
            CreateMap<AddContactDto, Contact>();
            CreateMap<UpdateContactDto, Contact>();
            CreateMap<Contact, UpdateContactDto>();
        }
    }
}
