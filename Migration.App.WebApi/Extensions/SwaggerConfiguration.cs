using Microsoft.OpenApi.Models;
using Migration.App.WebApi.Filters;
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
                opt.DocumentFilter<SwaggerDocsFilter>();

                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Migration.App API", Version = "v1" });

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
                opt.SwaggerEndpoint("/api-docs/v1/swagger.json", "Migration.App API V1");
            });

            return applicationBuilder;
        }
    }
}
