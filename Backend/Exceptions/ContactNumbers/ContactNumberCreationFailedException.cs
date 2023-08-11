namespace Backend.Exceptions.ContactNumbers
{
    public class ContactNumberCreationFailedException : Exception
    {
        public ContactNumberCreationFailedException(string message) : base(message) { }
    }
}
