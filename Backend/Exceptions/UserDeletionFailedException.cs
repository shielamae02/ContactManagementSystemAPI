namespace Backend.Exceptions
{
    public class UserDeletionFailedException : Exception
    {
        public UserDeletionFailedException(string message) : base(message) { }
    }
}
