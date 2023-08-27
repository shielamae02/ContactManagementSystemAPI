using Backend.Entities;

namespace Backend.Services.UserAuditService
{
    public interface IUserAuditService
    {
        Task UserAuthenticationAudit(User user, string action, string details);
    }
}
