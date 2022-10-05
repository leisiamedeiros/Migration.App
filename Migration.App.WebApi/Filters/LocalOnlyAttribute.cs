using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Migration.App.WebApi.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class LocalOnlyAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        { }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var environment = context.HttpContext.RequestServices.GetService<IWebHostEnvironment>();
            if (environment?.EnvironmentName is not "Local")
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}
