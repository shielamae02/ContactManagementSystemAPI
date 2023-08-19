using AutoMapper;
using Backend.Entities;
using Backend.Models.Auths;

namespace Backend.Mapper
{
    public class AuthMapper : Profile
    {
        public AuthMapper()
        {
            CreateMap<User, UserLoginDto>()
                .ReverseMap();

            CreateMap<User, UserRegisterDto>()
                .ReverseMap()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.FirstName)))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => CapitalizeFirstLetter(src.LastName)));


            CreateMap<User, AuthUserDto>()
                .ReverseMap();
            CreateMap<User, UpdateUserDto>()
                .ReverseMap();

        }

        private string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            return char.ToUpper(input[0]) + input.Substring(1);
        }
    }
}
    