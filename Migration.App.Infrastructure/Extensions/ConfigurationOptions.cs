
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Migration.App.Infrastructure.Extensions
{
    public static class ConfigurationOptions
    {
        public static IServiceCollection AddConfigurationOptions(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SqlServerOptions>(configuration.GetSection(SqlServerOptions.ConnectionStrings));

            return services;
        }
    }

    public class SqlServerOptions
    {
        public const string ConnectionStrings = "ConnectionStrings";
        public string SqlServer { get; set; } = string.Empty;
    }
}
