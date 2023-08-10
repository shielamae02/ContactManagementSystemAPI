using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Entities
{
    public class ContactNumber
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ContactId")]
        public int ContactId { get; set; }
        [JsonIgnore]
        public Contact Contact { get; set; }

        [Required]
        [MaxLength(15)]
        public string Number { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Label { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
