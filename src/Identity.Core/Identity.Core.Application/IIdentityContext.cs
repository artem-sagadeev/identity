using Identity.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Identity.Core.Application
{
    public interface IIdentityContext
    {
        DbSet<User> Users { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}