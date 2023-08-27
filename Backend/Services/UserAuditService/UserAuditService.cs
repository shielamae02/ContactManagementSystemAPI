using Backend.Entities;
using Backend.Repositories.UserAudits;

namespace Backend.Services.UserAuditService
{
    public class UserAuditService : IUserAuditService
    {
        private readonly IUserAuditRepository _userAuditRepository;

        public UserAuditService(IUserAuditRepository userAuditRepository)
        {
            _userAuditRepository = userAuditRepository ?? throw new ArgumentException(nameof(userAuditRepository));
        }

        public async Task UserAuthenticationAudit(User user, string action, string details)
        {
            var userAudit = new UserAudit()
            {
                UserId = user.Id,
                User = user,
                Action = action,
                Details = details
            };

            await _userAuditRepository.AddUserAudit(userAudit);
        }
    }
}
