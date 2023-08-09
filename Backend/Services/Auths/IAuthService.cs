using Backend.Models.Auths;
using Microsoft.AspNetCore.Identity;

namespace Backend.Services.Auths
{
    public interface IAuthService
    {
        Task<AuthUserDto> AuthLogin(UserLoginDto request);
        Task<AuthUserDto> AuthRegister(UserRegisterDto request);
    }
}
