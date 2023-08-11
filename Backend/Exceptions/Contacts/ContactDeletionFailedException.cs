namespace Backend.Exceptions.Contacts
{
    public class ContactDeletionFailedException : Exception
    {
        public ContactDeletionFailedException(string message) : base(message) { }
    }
}
