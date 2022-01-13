using System.Linq;
using System.Net;

namespace pizza.delivery.Application.Models.Responses
{
    public class HttpInternalServerErrorResponse : HttpResponse
    {
        public string[] Errors { get; }

        public HttpInternalServerErrorResponse(params string[] errors)
           : base(HttpStatusCode.InternalServerError)
        {
            if (errors?.Any() ?? false)
            {
                Errors = errors;
            }
        }
    }
}
