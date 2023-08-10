namespace Backend.Exceptions
{
    public class ContactNumberUpdateFailedException : Exception
    {
        public ContactNumberUpdateFailedException(string message) : base(message) { }
    }
}
