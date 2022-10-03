using Migration.App.Creator.Models;

namespace Migration.App.Infrastructure.Interfaces
{
    public interface IMigrationRepository
    {
        Task<IEnumerable<VersionInfo>> GetMigrationsAppliedAsync();
        Task Migrate();
    }
}
