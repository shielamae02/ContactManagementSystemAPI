namespace Backend.Exceptions.Contacts
{
    public class ContactCreationFailedException : Exception
    {
        public ContactCreationFailedException(string message) : base(message) { }
    }
}
