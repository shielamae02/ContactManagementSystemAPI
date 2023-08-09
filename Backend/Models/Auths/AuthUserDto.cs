using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Auths
{
    public class AuthUserDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
