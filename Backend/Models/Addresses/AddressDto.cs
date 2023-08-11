namespace Backend.Models.Addresses
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Details { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
    }
}
