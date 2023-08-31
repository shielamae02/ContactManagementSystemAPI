using System;
using Backend.Data;
using Backend.Entities;

namespace Backend.Repositories.ContactAudits
{
    /// <summary>
    /// Repository for managing contact audit records.
    /// </summary>
    public class ContactAuditRepository : IContactAuditRepository
    {
        private readonly DataContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactAuditRepository"/> class.
        /// </summary>
        /// <param name="context">The data context used for database operations.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="context"/> is null.</exception>
        public ContactAuditRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task AddContactAudit(ContactAudit contactAudit)
        {
            _context.ContactAudits.Add(contactAudit);
            await _context.SaveChangesAsync();
        }
    }
}
