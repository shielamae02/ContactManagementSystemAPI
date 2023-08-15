using AutoMapper;
using Backend.Entities;
using Backend.Models.ContactNumbers;

namespace Backend.Mapper
{
    public class ContactNumberMapper : Profile
    {
        public ContactNumberMapper()
        {
            CreateMap<ContactNumber, ContactNumberDto>();
            CreateMap<AddContactNumberDto, ContactNumber>();
            CreateMap<UpdateContactNumberDto, ContactNumber>()
                .ReverseMap();
        }
    }
}
