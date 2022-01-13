using System.Linq;
using System.Net;

namespace pizza.delivery.Application.Models.Responses
{
    public class HttpBadRequestResponse : HttpResponse
    {
        public string[] Errors { get; }

        public HttpBadRequestResponse(params string[] errors)
             : base(HttpStatusCode.BadRequest)
        {
            if (errors?.Any() ?? false)
            {
                Errors = errors;
            }
        }
    }
}
