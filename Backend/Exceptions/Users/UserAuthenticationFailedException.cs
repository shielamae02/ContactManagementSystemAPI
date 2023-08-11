namespace Backend.Exceptions.Users
{
    public class UserAuthenticationFailedException : Exception
    {
        public UserAuthenticationFailedException(string message) : base(message) { }
    }
}
