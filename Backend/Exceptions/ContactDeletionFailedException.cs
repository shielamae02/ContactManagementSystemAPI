namespace Backend.Exceptions
{
    public class ContactDeletionFailedException : Exception
    {
        public ContactDeletionFailedException(string message) : base(message) { }
    }
}
