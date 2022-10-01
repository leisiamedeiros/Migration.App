using System.Reflection;

namespace Migration.App.WebApi.Extensions
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerServiceConfig(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(opt =>
            {
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            return services;
        }

        public static IApplicationBuilder AddSwaggerApplicationConfig(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseSwagger(opt =>
            {
                opt.RouteTemplate = "api-docs/{documentName}/swagger.json";
            });
            applicationBuilder.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/api-docs/v1/swagger.json", "v1");
            });

            return applicationBuilder;
        }
    }
}
