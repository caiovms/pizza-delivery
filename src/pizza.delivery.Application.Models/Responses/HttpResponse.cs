using System.Net;

namespace pizza.delivery.Application.Models.Responses
{
    public class HttpResponse
    {
        public HttpStatusCode HttpStatusCode { get; }

        public HttpResponse(HttpStatusCode httpStatusCode)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
