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
        public int ContactId { get; set; }
        [JsonIgnore]
        public Contact Contact { get; set; }

        [Required]
        [MaxLength(100)]
        public string Details { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string Label { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
