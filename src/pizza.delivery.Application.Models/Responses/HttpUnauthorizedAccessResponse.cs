using System.Linq;
using System.Net;

namespace pizza.delivery.Application.Models.Responses
{
    public class HttpUnauthorizedAccessResponse : HttpResponse
    {
        public string[] Errors { get; }

        public HttpUnauthorizedAccessResponse(params string[] errors)
            : base(HttpStatusCode.Unauthorized)
        {
            if (errors?.Any() ?? false)
            {
                Errors = errors;
            }
        }
    }
}
