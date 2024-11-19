using ApiLayer.DTOs;
using FluentValidation;

namespace ApiLayer.Validators
{
    public class EventDtoValidator : AbstractValidator<EventDto>
    {
        public EventDtoValidator()
        {
            RuleFor(e => e.Title).NotEmpty().WithMessage("Title is required.");
            RuleFor(e => e.Date).GreaterThan(DateTime.Now).WithMessage("Event date must be in the future.");
            RuleFor(e => e.LocationId).GreaterThan(0).WithMessage("LocationId is required.");
        }
    }
}
