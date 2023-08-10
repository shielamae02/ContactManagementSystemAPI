namespace Backend.Exceptions
{
    public class ContactNumberDeletionFailedException : Exception
    {
        public ContactNumberDeletionFailedException(string message) : base(message) { }    
    }
}
