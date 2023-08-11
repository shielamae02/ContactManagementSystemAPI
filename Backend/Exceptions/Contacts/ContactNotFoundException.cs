namespace Backend.Exceptions.Contacts
{
    public class ContactNotFoundException : Exception
    {
        public ContactNotFoundException(string message) : base(message) { }
    }
}
