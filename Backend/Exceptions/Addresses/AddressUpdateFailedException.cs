namespace Backend.Exceptions.Addresses
{
    public class AddressUpdateFailedException : Exception
    {
        public AddressUpdateFailedException(string message)  : base(message) { }
    }
}
