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
                .ReverseMap();
            CreateMap<User, AuthUserDto>()
                .ReverseMap();
            CreateMap<User, UpdateUserDto>()
                .ReverseMap();
        }
    }
}
    