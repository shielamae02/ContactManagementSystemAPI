namespace Backend.Exceptions.Addresses
{
    public class AddressDeletionFailedException : Exception
    {
        public AddressDeletionFailedException(string message) : base (message) { }
    }
}
