using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using pizza.delivery.API.Extensions;
using pizza.delivery.Application.Models.Responses;

namespace pizza.delivery.API.Attributes
{
    public class ValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context != null && context.ModelState != null && !context.ModelState.IsValid)
            {
                var errors = context.ModelState.GetErrors();

                context.Result = new BadRequestObjectResult(new HttpBadRequestResponse(errors));
            }

            base.OnActionExecuting(context);
        }
    }
}