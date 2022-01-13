using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using pizza.delivery.API.GlobalExceptionHandling;
using System;
using System.Threading.Tasks;

namespace pizza.delivery.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<ExceptionHandlerMiddleware> middlewareLogger, IExceptionHandler middlewareHandler)
        {
            try
            {
                await _next(context).ConfigureAwait(continueOnCapturedContext: false);
            }
            catch (Exception ex)
            {
                try
                {
                    middlewareLogger?.LogError(ex.ToString());
                }
                catch { }

                if (middlewareHandler != null)
                {
                    await middlewareHandler.HandleExceptionAsync(context, ex).ConfigureAwait(continueOnCapturedContext: false);
                }
            }
        }
    }
}