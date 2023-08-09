using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Backend.Models.Auths
{
    public class UserLoginDto
    {
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Required(ErrorMessage = "Email address is required.")]
        [MinLength(3, ErrorMessage = "Email address must be at least 3 characters long.")]
        [MaxLength(100, ErrorMessage = "Email address must not exceed 100 characters.")]
        public string EmailAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(3, ErrorMessage = "Password must be at least 3 characters long.")]
        [MaxLength(150, ErrorMessage = "Password must not exceed 150 characters.")]
        public string Password { get; set; } = string.Empty;

    }
}
