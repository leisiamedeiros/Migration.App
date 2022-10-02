using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
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

        public static IServiceCollection AddFluentMigration(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddFluentMigratorCore()
                .ConfigureRunner(cfg => cfg
                    .AddSqlServer()
                    .WithGlobalConnectionString(configuration["ConnectionStrings:SqlServer"])
                    .ScanIn(typeof(DependencyInjection).Assembly).For.Migrations().For.EmbeddedResources()
                ).AddLogging(logg => logg.AddFluentMigratorConsole());

            return services;
        }
    }
}
