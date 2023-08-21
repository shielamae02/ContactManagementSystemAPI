using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Addresses
{
    public class AddAddressDto
    {
        [Required(ErrorMessage = "Address details are required.")]
        [MinLength(3, ErrorMessage = "Address details must be at least 3 characters long.")]
        [MaxLength(100, ErrorMessage = "Address label must not exceed 100 characters.")]
        public string Details { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address type is required.")]
        [MinLength(3, ErrorMessage = "Address type must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "Address type label must not exceed 50 characters.")]
        public string Label { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
