namespace Backend.Exceptions.Users
{
    public class UserUpdateFailedException : Exception
    {
        public UserUpdateFailedException(string message) : base(message) { }
    }
}
