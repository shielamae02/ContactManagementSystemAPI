using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Backend.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string EmailAddress { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;



        public ICollection<ContactNumber> ContactNumbers { get; set; } = new List<ContactNumber>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
