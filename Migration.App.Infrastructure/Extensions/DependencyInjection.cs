using Microsoft.Extensions.DependencyInjection;
using Migration.App.Infrastructure.Interfaces;
using Migration.App.Infrastructure.Repository;

namespace Migration.App.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMigrationRepository, MigrationRepository>();

            return services;
        }
    }
}
