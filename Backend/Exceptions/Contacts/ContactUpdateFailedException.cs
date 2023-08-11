namespace Backend.Exceptions.Contacts
{
    public class ContactUpdateFailedException : Exception
    {
        public ContactUpdateFailedException(string message) : base(message) { }
    }
}
