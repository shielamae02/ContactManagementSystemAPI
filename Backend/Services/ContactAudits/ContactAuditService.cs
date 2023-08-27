using Backend.Entities;
using Backend.Repositories.ContactAudits;

namespace Backend.Services.ContactAudits
{
    public class ContactAuditService : IContactAuditService
    {
        private IContactAuditRepository _contactAuditRepository;
        public ContactAuditService(IContactAuditRepository contactAuditRepository)
        {
            _contactAuditRepository = contactAuditRepository ?? throw new ArgumentNullException(nameof(contactAuditRepository));
        }
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
