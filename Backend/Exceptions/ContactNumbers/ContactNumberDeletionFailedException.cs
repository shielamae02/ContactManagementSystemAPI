namespace Backend.Exceptions.ContactNumbers
{
    public class ContactNumberDeletionFailedException : Exception
    {
        public ContactNumberDeletionFailedException(string message) : base(message) { }
    }
}
