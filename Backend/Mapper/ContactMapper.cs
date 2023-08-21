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
                .ReverseMap()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.FirstName)))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.LastName)));

            CreateMap<AddContactDto, Contact>()
                 .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.FirstName)))
                 .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.LastName)));



            CreateMap<UpdateContactDto, Contact>()
                .ReverseMap()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.FirstName)))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.LastName)));

        }

        private string CapitalizeFirstLetter(string input)
        {
            Console.WriteLine($"Input: {input}");
            string[] text = input.Split(" ");
            for (int i = 0; i < text.Length; i++)
            {
                text[i] = char.ToUpper(text[i][0]) + text[i][1..];
            }

            Console.WriteLine($"Input: {string.Join(" ", text)}");
            return string.Join(" ", text);
        }
    }
}
