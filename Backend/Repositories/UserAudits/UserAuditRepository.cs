using Backend.Data;
using Backend.Entities;

namespace Backend.Repositories.UserAudits
{
    public class UserAuditRepository : IUserAuditRepository
    {
        private readonly DataContext _context;

        public UserAuditRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddUserAudit(UserAudit userAudit)
        {
            _context.UserAudits.Add(userAudit);
            await _context.SaveChangesAsync();
        }
    }
}
