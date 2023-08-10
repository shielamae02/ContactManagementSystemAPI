namespace Backend.Exceptions
{
    public class UserAuthenticationFailedException : Exception
    {
        public UserAuthenticationFailedException(string message) : base(message) { }
    }
}
