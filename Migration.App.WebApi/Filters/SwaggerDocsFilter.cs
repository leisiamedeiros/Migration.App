using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Migration.App.WebApi.Filters
{
    public class SwaggerDocsFilter : IDocumentFilter
    {
        private readonly IWebHostEnvironment _environment;

        public SwaggerDocsFilter(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            if (_environment.EnvironmentName is not "Local")
            {
                var pathsToRemove = swaggerDoc.Paths.Where(path => path.Key.Contains("/local"));

                foreach (var path in pathsToRemove)
                {
                    swaggerDoc.Paths.Remove(path.Key);
                }
            }
        }
    }
}
