using AutoMapper;
using Backend.Entities;
using Backend.Models.Contacts;

namespace Backend.Mapper
{
    public class ContactMapper : Profile
    {
        public ContactMapper()
        {
            CreateMap<Contact, ContactDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.FirstName)))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.LastName)))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.EmailAddress)));

            CreateMap<AddContactDto, Contact>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.FirstName)))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.LastName)))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.EmailAddress)));

            CreateMap<UpdateContactDto, Contact>()
                .ReverseMap()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.FirstName)))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.LastName)))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.EmailAddress)));

        }

        private string CapitalizeFirstLetter(string input)
        {
            string[] text = input.Split(" ");
            for (int i = 0; i < text.Length; i++)
            {
                text[i] = char.ToUpper(text[i][0]) + text[i].Substring(1);
            }

            return string.Join(" ", text);
        }
    }
}
