using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Addresses
{
    public class AddAddressDto
    {
        [Required(ErrorMessage = "Address is required.")]
        [MinLength(5, ErrorMessage = "Address must be at least 5 characters long.")]
        [MaxLength(100, ErrorMessage = "Address must not exceed 100 characters.")]
        public string AddressDetails { get; set; } = string.Empty;
    }
}
