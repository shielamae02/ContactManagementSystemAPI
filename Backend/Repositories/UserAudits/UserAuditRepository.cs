using System;
using Backend.Data;
using Backend.Entities;

namespace Backend.Repositories.UserAudits
{
    /// <summary>
    /// Repository for managing user audit records.
    /// </summary>
    public class UserAuditRepository : IUserAuditRepository
    {
        private readonly DataContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAuditRepository"/> class.
        /// </summary>
        /// <param name="context">The data context used for database operations.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="context"/> is null.</exception>
        public UserAuditRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Adds a new user audit record to the repository.
        /// </summary>
        /// <param name="userAudit">The user audit record to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddUserAudit(UserAudit userAudit)
        {
            _context.UserAudits.Add(userAudit);
            await _context.SaveChangesAsync();
        }
    }
}
