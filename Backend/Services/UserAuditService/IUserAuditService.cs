using Backend.Entities;

namespace Backend.Services.UserAuditService
{
    /// <summary>
    /// Represents a service for auditing user authentication-related actions.
    /// </summary>
    public interface IUserAuditService
    {
        /// <summary>
        /// Records an audit of a user authentication-related action.
        /// </summary>
        /// <param name="user">The user for whom the authentication action is audited.</param>
        /// <param name="action">The action being audited (e.g., login, logout).</param>
        /// <param name="details">Additional details about the action.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UserAuthenticationAudit(User user, string action, string details);
    }
}
