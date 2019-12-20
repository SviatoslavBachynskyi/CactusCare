using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CactusCare.Abstractions.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CactusCare.API
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, 
            ILogger<ExceptionMiddleware> logger
        )
        {
            _next = next;
            this._logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (StatusCodeException exception)
            {
                this._logger.LogInformation($"Status code error: {exception}");
                await HandleExceptionAsync(httpContext, exception.Message, exception.StatusCode, exception.ContentType);
            }
            catch (ValidationException exception)
            {
                this._logger.LogInformation($"Validation error: {exception}");
                await HandleExceptionAsync(httpContext, $"Validation error: {exception.Errors.Select(x => x.ErrorMessage).Single()}", 400);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Something went wrong: {exception}");
                await HandleExceptionAsync(httpContext, $"Internal server error", 500);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, string message, int statusCode, string contentType = "text/plain")
        {
            context.Response.ContentType = contentType;
            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(message);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
