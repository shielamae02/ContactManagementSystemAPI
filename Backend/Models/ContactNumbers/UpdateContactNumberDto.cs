using System.ComponentModel.DataAnnotations;

namespace Backend.Models.ContactNumbers
{
    public class UpdateContactNumberDto
    {
        [Required(ErrorMessage = "Contact number is required.")]
        [MinLength(11, ErrorMessage = "Contact number must be at least 11 digits long.")]
        [MaxLength(15, ErrorMessage = "Contact number must not exceed 15 digits.")]
        public string Number { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact number label is required.")]
        [MinLength(3, ErrorMessage = "Contact number label must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "Contact number label must not exceed 50 characters.")]
        public string Label { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
