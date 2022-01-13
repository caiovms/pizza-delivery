using FluentValidation;
using pizza.delivery.Application.Models.Requests;

namespace pizza.delivery.Application.Validators
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderValidator()
        {
            RuleFor(m => m.ClientId).NotNull().NotEmpty();
            RuleFor(m => m.Description).NotNull().NotEmpty();
        }
    }
}