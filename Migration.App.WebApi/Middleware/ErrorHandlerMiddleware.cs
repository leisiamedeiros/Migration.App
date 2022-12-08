﻿using Migration.App.WebApi.Transport;
using System.Net;
using System.Text.Json;

namespace Migration.App.WebApi.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var id = Guid.NewGuid().ToString();
                _logger.LogError(ex, $"Something went wrong with id: {id}");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var errorResponse = ErrorResponse.GetErrorResponseFromError(new Error
                {
                    Code = id,
                    Title = "Status500InternalServerError",
                    Detail = "An error occurred when processing your request",
                });

                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
            }
        }
    }
}
