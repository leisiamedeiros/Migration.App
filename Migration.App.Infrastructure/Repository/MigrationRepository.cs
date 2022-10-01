using Microsoft.Extensions.Options;
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

        public async Task<string> GetMigrationsAsync()
        {
            return await Task.FromResult(_options.SqlServer);
        }
    }
}
