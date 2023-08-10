namespace Backend.Exceptions
{
    public class UserDeletionFailed : Exception
    {
        public UserDeletionFailed(string message) : base(message) { }
    }
}
