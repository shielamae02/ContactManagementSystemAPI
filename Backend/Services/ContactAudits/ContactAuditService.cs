using System;
using Backend.Entities;
using Backend.Repositories.ContactAudits;

namespace Backend.Services.ContactAudits
{
    /// <summary>
    /// Service for auditing contact-related actions.
    /// </summary>
    public class ContactAuditService : IContactAuditService
    {
        private IContactAuditRepository _contactAuditRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactAuditService"/> class.
        /// </summary>
        /// <param name="contactAuditRepository">The repository for contact audits.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="contactAuditRepository"/> is null.</exception>
        public ContactAuditService(IContactAuditRepository contactAuditRepository)
        {
            _contactAuditRepository = contactAuditRepository ?? throw new ArgumentNullException(nameof(contactAuditRepository));
        }

        /// <inheritdoc/>
        public async Task AuditContact(User user, string action, string details)
        {
            var auditContact = new ContactAudit()
            {
                User = user,
                UserId = user.Id,
                Action = action,
                Details = details
            };

            await _contactAuditRepository.AddContactAudit(auditContact);
        }
    }
}
