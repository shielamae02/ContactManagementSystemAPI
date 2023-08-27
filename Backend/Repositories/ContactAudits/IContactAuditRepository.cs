using Backend.Entities;

namespace Backend.Repositories.ContactAudits
{
    public interface IContactAuditRepository
    {
        Task AddContactAudit(ContactAudit contactAudit);
    }
}
