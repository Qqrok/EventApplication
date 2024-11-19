using ApiLayer.DTOs;
using FluentValidation;

namespace ApiLayer.Validators
{
    public class TicketDtoValidator : AbstractValidator<TicketDto>
    {
        public TicketDtoValidator()
        {
            RuleFor(t => t.UserId).GreaterThan(0).WithMessage("UserId is required.");
            RuleFor(t => t.EventId).GreaterThan(0).WithMessage("EventId is required.");
            RuleFor(t => t.PurchaseDate).NotEmpty().WithMessage("Purchase date is required.");
        }
    }
}
