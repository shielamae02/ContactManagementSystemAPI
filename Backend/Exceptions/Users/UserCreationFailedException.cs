namespace Backend.Exceptions.Users
{
    public class UserCreationFailedException : Exception
    {
        public UserCreationFailedException(string message) : base(message) { }
    }
}
