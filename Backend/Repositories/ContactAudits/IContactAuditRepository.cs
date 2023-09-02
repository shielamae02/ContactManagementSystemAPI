using Backend.Entities;

namespace Backend.Repositories.ContactAudits
{
    /// <summary>
    /// Represents a repository for managing contact audit records.
    /// </summary>
    public interface IContactAuditRepository
    {
        /// <summary>
        /// Adds a new contact audit record to the repository.
        /// </summary>
        /// <param name="contactAudit">The contact audit record to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddContactAudit(ContactAudit contactAudit);
    }
}
