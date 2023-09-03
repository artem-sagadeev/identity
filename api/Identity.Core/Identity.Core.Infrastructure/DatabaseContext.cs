using Identity.Core.Application;
using Identity.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Identity.Core.Infrastructure
{
    public class DatabaseContext : DbContext, IIdentityContext
    {
        public DbSet<User> Users { get; private set; }
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    }
}