using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Migration.App.WebApi.Transport;

namespace Migration.App.WebApi.Filters
{
    public class ModelStateValidationActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorResponse = ErrorResponse.GetErrorResponseFromModelState(context.ModelState);

                context.Result = new BadRequestObjectResult(errorResponse);
            }
            else
            {
                await next();
            }
        }
    }
}
