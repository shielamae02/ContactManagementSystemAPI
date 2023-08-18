using Backend.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text.Json.Serialization;

namespace Backend.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        [JsonIgnore]
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }


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


       [AtLeastOneContactNumber]
       public ICollection<ContactNumber> ContactNumbers { get; set; } = new List<ContactNumber>();
       public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
