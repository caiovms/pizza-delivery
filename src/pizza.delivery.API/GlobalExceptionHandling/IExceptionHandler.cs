using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace pizza.delivery.API.GlobalExceptionHandling
{
    public interface IExceptionHandler
    {
        Task HandleExceptionAsync(HttpContext httpContext, Exception exception);
    }
}
