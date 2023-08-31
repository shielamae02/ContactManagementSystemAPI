using Backend.Entities;

namespace Backend.Services.ContactAudits
{
    /// <summary>
    /// Represents a service for auditing contact-related actions.
    /// </summary>
    public interface IContactAuditService
    {
        /// <summary>
        /// Records an audit of a contact-related action.
        /// </summary>
        /// <param name="user">The user performing the action.</param>
        /// <param name="action">The action being audited (e.g., create, update, delete).</param>
        /// <param name="details">Additional details about the action.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AuditContact(User user, string action, string details);
    }
}
