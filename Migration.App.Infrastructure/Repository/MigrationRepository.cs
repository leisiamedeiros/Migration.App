using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Migration.App.Creator.Models;
using Migration.App.Infrastructure.Extensions;
using Migration.App.Infrastructure.Interfaces;

namespace Migration.App.Infrastructure.Repository
{
    public class MigrationRepository : IMigrationRepository
    {
        private readonly SqlServerOptions _options;

        public MigrationRepository(IOptions<SqlServerOptions> options)
        {
            _options = options.Value;
        }

        public async Task<IEnumerable<VersionInfo>> GetMigrationsAppliedAsync()
        {
            using var conn = new SqlConnection(_options.SqlServer);

            return await conn.QueryAsync<VersionInfo>(
                "SELECT [Version], [AppliedOn], [Description] FROM [dbo].[VersionInfo]"
            );
        }

        public Task Migrate()
        {
            return Task.CompletedTask;
        }
    }
}
