namespace Backend.Exceptions.ContactNumbers
{
    public class ContactNumberNotFoundException : Exception
    {
        public ContactNumberNotFoundException(string message) : base(message) { }
    }
}
