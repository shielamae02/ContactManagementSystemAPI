using Backend.Data;
using Backend.Entities;

namespace Backend.Repositories.ContactAudits
{
    public class ContactAuditRepository : IContactAuditRepository
    {
        private readonly DataContext _context;
        public ContactAuditRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddContactAudit(ContactAudit contactAudit)
        {
            _context.ContactAudits.Add(contactAudit);
            await _context.SaveChangesAsync();
        }
    }
}
