using Backend.Models.Addresses;
using Backend.Models.ContactNumbers;
using System.ComponentModel.DataAnnotations;

public class AddContactDto
{
    [Required(ErrorMessage = "First name is required.")]
    [MinLength(3, ErrorMessage = "First name must be at least 3 characters long.")]
    [MaxLength(50, ErrorMessage = "First name must not exceed 50 characters.")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last name is required.")]
    [MinLength(3, ErrorMessage = "Last name must be at least 3 characters long.")]
    [MaxLength(50, ErrorMessage = "Last name must not exceed 50 characters.")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email address is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public string EmailAddress { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public List<AddContactNumberDto> ContactNumbers { get; set; } = new List<AddContactNumberDto>();
    public List<AddAddressDto> Addresses { get; set; } = new List<AddAddressDto>();
}
