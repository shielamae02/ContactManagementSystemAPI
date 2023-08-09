using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ContactId")]
        [JsonIgnore]
        public int ContactId { get; set; }
        [JsonIgnore]
        public Contact Contact { get; set; }

        [Required]
        [MaxLength(100)]
        public string AddressDetails { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string AddressType { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
