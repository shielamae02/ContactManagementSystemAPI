namespace Backend.Exceptions.Addresses
{
    public class AddressCreationFailedException : Exception
    {
        public AddressCreationFailedException(string message) : base(message) { }
    }
}
