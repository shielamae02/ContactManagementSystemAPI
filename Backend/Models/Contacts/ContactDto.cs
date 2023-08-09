using Backend.Entities;

namespace Backend.Models.Contacts
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;

        public ICollection<ContactNumber> ContactNumbers { get; set; } = new List<ContactNumber>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();

    }
}
