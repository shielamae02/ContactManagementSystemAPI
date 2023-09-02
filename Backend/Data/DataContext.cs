using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public void Initialize()
        {
            Database.Migrate();
            SaveChanges();
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Contact> Contacts => Set<Contact>();
        public DbSet<UserAudit> UserAudits => Set<UserAudit>();
        public DbSet<ContactAudit> ContactAudits => Set<ContactAudit>();

    }
}
