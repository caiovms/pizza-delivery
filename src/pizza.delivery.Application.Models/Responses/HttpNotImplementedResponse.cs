using System.Linq;
using System.Net;

namespace pizza.delivery.Application.Models.Responses
{
    public class HttpNotImplementedResponse : HttpResponse
    {
        public string[] Errors { get; }

        public HttpNotImplementedResponse(params string[] errors)
            : base(HttpStatusCode.NotImplemented)
        {
            if (errors?.Any() ?? false)
            {
                Errors = errors;
            }
        }
    }
}
