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
            string[] text = input.Split(" ");
            for (int i = 0; i < text.Length; i++)
            {
                text[i] = char.ToUpper(text[i][0]) + text[i].Substring(1);
            }

            return string.Join(" ", text);
        }
    }
}
