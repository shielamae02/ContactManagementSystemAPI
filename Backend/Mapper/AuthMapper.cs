using AutoMapper;
using Backend.Entities;
using Backend.Models.Auths;

namespace Backend.Mapper
{
    public class AuthMapper : Profile
    {
        public AuthMapper()
        {
            CreateMap<User, UserLoginDto>();
            CreateMap<User, UserRegisterDto>();
            CreateMap<User, AuthUserDto>();
            CreateMap<UserLoginDto, User>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<AuthUserDto, User>();
        }
    }
}
