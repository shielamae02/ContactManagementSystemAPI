using AutoMapper;
using Backend.Entities;
using Backend.Models.ContactNumbers;

namespace Backend.Mapper
{
    public class ContactNumberMapper : Profile
    {
        public ContactNumberMapper()
        {
            CreateMap<ContactNumber, ContactNumberDto>()
                .ReverseMap()
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.Label)));

            CreateMap<AddContactNumberDto, ContactNumber>()
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.Label)));

            CreateMap<UpdateContactNumberDto, ContactNumber>()
                .ReverseMap()
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.Label)));
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
