using ApiLayer.DTOs;
using FluentValidation;

namespace ApiLayer.Validators
{
    public class LocationDtoValidator : AbstractValidator<LocationDto>
    {
        public LocationDtoValidator()
        {
            RuleFor(l => l.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(l => l.Address).NotEmpty().WithMessage("Address is required.");
        }
    }
}
