namespace Backend.Models.Contacts
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public bool Favorite { get; set; } = false;

        public string ContactNumber1 { get; set; } = string.Empty;
        public string NumberLabel1 { get; set; } = string.Empty;


        public string? ContactNumber2 { get; set; } = string.Empty;
        public string? NumberLabel2 { get; set; } = string.Empty;


        public string? ContactNumber3 { get; set; } = string.Empty;
        public string? NumberLabel3 { get; set; } = string.Empty;

        public string AddressDetails1 { get; set; } = string.Empty;
        public string AddressLabel1 { get; set; } = string.Empty;

        public string? AddressDetails2 { get; set; } = string.Empty;
        public string? AddressLabel2 { get; set; } = string.Empty;

    }
}
