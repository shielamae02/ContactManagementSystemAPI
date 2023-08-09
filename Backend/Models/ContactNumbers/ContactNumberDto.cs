namespace Backend.Models.ContactNumbers
{
    public class ContactNumberDto
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
    }
}
