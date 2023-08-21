using Backend.Models.Addresses;
using Backend.Models.ContactNumbers;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Contacts
{
    public class UpdateContactDto
    {
        [Required(ErrorMessage = "First name is required.")]
        [MinLength(3, ErrorMessage = "First name must be at least be 3 chracters long.")]
        [MaxLength(50, ErrorMessage = "First name must not exceed 50 characters.")]
        public string FirstName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Last name is required.")]
        [MinLength(3, ErrorMessage = "Last name must be at least be 3 chracters long.")]
        [MaxLength(50, ErrorMessage = "Last name must not exceed 50 characters.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string EmailAddress { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<UpdateContactNumberDto> ContactNumbers { get; set; } = new List<UpdateContactNumberDto>();
        public List<UpdateAddressDto> Addresses { get; set; } = new List<UpdateAddressDto>();
    }
}
