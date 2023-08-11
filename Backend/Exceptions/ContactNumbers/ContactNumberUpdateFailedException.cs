namespace Backend.Exceptions.ContactNumbers
{
    public class ContactNumberUpdateFailedException : Exception
    {
        public ContactNumberUpdateFailedException(string message) : base(message) { }
    }
}
