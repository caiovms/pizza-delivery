using Microsoft.AspNetCore.Http;
using System;
using System.Net.Mime;
using System.Threading.Tasks;
using pizza.delivery.Infrastructure.Exceptions;
using pizza.delivery.Infrastructure.Extensions;

namespace pizza.delivery.API.GlobalExceptionHandling
{
    using pizza.delivery.Application.Models.Responses;

    public class ExceptionHandler : IExceptionHandler
    {
        public async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            var response = FromException(exception);

            httpContext.Response.StatusCode = response.HttpStatusCode.GetHashCode();
            httpContext.Response.ContentType = MediaTypeNames.Application.Json;

            var json = response.ToJson();
            await httpContext.Response.WriteAsync(json).ConfigureAwait(continueOnCapturedContext: false);
        }

        private static HttpResponse FromException(Exception exception)
        {
            var errors = string.IsNullOrWhiteSpace(exception.Message) ? Array.Empty<string>() : new[] { exception.Message };

            HttpResponse response = exception switch
            {
                BadRequestException => new HttpBadRequestResponse(errors),
                UnauthorizedAccessException => new HttpUnauthorizedAccessResponse(errors),
                NotFoundException => new HttpNotFoundResponse(errors),
                NotImplementedException => new HttpNotImplementedResponse(errors),
                _ => new HttpInternalServerErrorResponse(errors),
            };

            return response;
        }
    }
}