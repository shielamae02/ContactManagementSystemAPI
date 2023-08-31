using Backend.Entities;

namespace Backend.Repositories.UserAudits
{
    /// <summary>
    /// Represents a repository for managing user audit records.
    /// </summary>
    public interface IUserAuditRepository
    {
        /// <summary>
        /// Adds a new user audit record to the repository.
        /// </summary>
        /// <param name="userAudit">The user audit record to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddUserAudit(UserAudit userAudit);
    }
}
