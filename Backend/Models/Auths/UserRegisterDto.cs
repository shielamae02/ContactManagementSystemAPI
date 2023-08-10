using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Auths
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "First name is required.")]
        [MinLength(3, ErrorMessage = "First name must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "First name must not exceed 50 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        [MinLength(3, ErrorMessage = "Last name must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "Last name must not exceed 50 characters.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Username is required.")]
        [MinLength(3, ErrorMessage = "Username must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "Username must not exceed 50 characters.")]
        public string UserName { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Required(ErrorMessage = "Email address is required.")]
        [MinLength(3, ErrorMessage = "Email address must be at least 3 characters long.")]
        [MaxLength(100, ErrorMessage = "Email address must not exceed 100 characters.")]
        public string EmailAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(3, ErrorMessage = "Password must be at least 3 characters long.")]
        [MaxLength(150, ErrorMessage = "Password must not exceed 150 characters.")]
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "Password does not match.")]
        [Required(ErrorMessage = "Please confirm your password.")]
        [MinLength(3, ErrorMessage = "Password must be at least 3 characters long.")]
        [MaxLength(150, ErrorMessage = "Password must not exceed 150 characters.")]
        public string ConfirmPassword { get; set; } = string.Empty;



    }
}
