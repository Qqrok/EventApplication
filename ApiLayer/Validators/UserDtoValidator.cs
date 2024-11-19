using ApiLayer.DTOs;
using FluentValidation;

namespace ApiLayer.Validators
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(u => u.Email).NotEmpty().EmailAddress().WithMessage("Valid email is required.");
        }
    }
}
