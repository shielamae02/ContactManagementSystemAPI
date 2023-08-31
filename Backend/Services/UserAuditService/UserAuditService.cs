using Backend.Entities;
using Backend.Repositories.UserAudits;

namespace Backend.Services.UserAuditService
{
    /// <summary>
    /// Service for auditing user authentication-related actions.
    /// </summary>
    public class UserAuditService : IUserAuditService
    {
        private readonly IUserAuditRepository _userAuditRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAuditService"/> class.
        /// </summary>
        /// <param name="userAuditRepository">The repository for user audit records.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="userAuditRepository"/> is null.</exception>
        public UserAuditService(IUserAuditRepository userAuditRepository)
        {
            _userAuditRepository = userAuditRepository ?? throw new ArgumentNullException(nameof(userAuditRepository));
        }

        /// <inheritdoc />
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
