namespace Backend.Exceptions.Addresses
{
    public class AddressNotFoundException : Exception
    {
        public AddressNotFoundException(string message) : base(message) { }
    }
}
