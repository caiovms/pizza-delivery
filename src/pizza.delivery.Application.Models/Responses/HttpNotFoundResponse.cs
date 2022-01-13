using System.Linq;
using System.Net;

namespace pizza.delivery.Application.Models.Responses
{
    public class HttpNotFoundResponse : HttpResponse
    {
        public string[] Errors { get; }

        public HttpNotFoundResponse(params string[] errors)
            : base(HttpStatusCode.NotFound)
        {
            if (errors?.Any() ?? false)
            {
                Errors = errors;
            }
        }
    }
}
