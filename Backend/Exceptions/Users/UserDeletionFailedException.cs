namespace Backend.Exceptions.Users
{
    public class UserDeletionFailedException : Exception
    {
        public UserDeletionFailedException(string message) : base(message) { }
    }
}
