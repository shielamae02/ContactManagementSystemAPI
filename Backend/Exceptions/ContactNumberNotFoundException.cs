namespace Backend.Exceptions
{
    public class ContactNumberNotFoundException : Exception
    {
        public ContactNumberNotFoundException(string message) : base(message) { }
    }
}
