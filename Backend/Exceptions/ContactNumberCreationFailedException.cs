namespace Backend.Exceptions
{
    public class ContactNumberCreationFailedException: Exception
    {
        public ContactNumberCreationFailedException(string message) : base(message) { }
    }
}
