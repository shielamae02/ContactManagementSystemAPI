using Backend.Entities;

namespace Backend.Repositories.UserAudits
{
    public interface IUserAuditRepository
    {
        Task AddUserAudit(UserAudit userAudit);
    }
}
