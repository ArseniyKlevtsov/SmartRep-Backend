using FluentValidation;
using SmartRep_Backend.Application.Dtos.AuthDtos.Requests;

namespace SmartRep_Backend.Application.Validators.AuthValidatros;
public class RegisterRequestDtoValidator : AbstractValidator<RegisterRequestDto>
{
    public RegisterRequestDtoValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage("The username cannot be empty.")
            .MaximumLength(50)
            .WithMessage("The username must be shorter than 50 characters.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("The password cannot be empty.")
            .MinimumLength(8)
            .WithMessage("The password must be at least 8 characters long.");
    }
}
