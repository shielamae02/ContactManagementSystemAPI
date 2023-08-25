using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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


        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string EmailAddress { get; set; } = string.Empty;

        public bool Favorite { get; set; } = false;


        [MaxLength(15)]
        public string ContactNumber1 { get; set; } = string.Empty;

        [MaxLength(20)]
        public string NumberLabel1 { get; set; } = string.Empty;


        [MaxLength(15)]
        public string? ContactNumber2 { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? NumberLabel2 { get; set; } = string.Empty;


        [MaxLength(15)]
        public string? ContactNumber3 { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? NumberLabel3 { get; set; } = string.Empty;



        [MaxLength(100)]
        public string AddressDetails1 { get; set; } = string.Empty;

        [MaxLength(20)]
        public string AddressLabel1 { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? AddressDetails2 { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? AddressLabel2 { get; set; } = string.Empty;


        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
