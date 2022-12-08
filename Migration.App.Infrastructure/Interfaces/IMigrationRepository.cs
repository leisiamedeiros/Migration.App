using Migration.App.Domain.Models;

namespace Migration.App.Infrastructure.Interfaces
{
    public interface IMigrationRepository
    {
        Task<IEnumerable<VersionInfo>> GetMigrationsAppliedAsync();
    }
}
