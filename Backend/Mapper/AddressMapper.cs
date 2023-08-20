using AutoMapper;
using Backend.Entities;
using Backend.Models.Addresses;

namespace Backend.Mapper
{
    public class AddressMapper : Profile
    {
        public AddressMapper()
        {

            CreateMap<Address, AddressDto>()
                .ReverseMap()
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.Details)))
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.Label)));

            CreateMap<AddAddressDto, Address>()
              .ReverseMap()
              .ForMember(dest => dest.Details, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.Details)))
              .ForMember(dest => dest.Label, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.Label)));

            CreateMap<UpdateAddressDto, Address>()
                .ReverseMap()
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.Details)))
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
