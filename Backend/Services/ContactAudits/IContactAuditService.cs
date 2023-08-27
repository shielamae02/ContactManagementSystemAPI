using Backend.Entities;

namespace Backend.Services.ContactAudits
{
    public interface IContactAuditService
    {
        Task AuditContact(User user, string action, string details);
    }
}
