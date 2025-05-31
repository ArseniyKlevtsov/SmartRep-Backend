using FluentValidation;
using SmartRep_Backend.Application.Dtos.AuthDtos.Requests;

namespace SmartRep_Backend.Application.Validators.AuthValidatros;
public class LoginRequestDtoValidator : AbstractValidator<LoginRequestDto>
{

    public LoginRequestDtoValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("The username cannot be empty.")
            .MaximumLength(50)
            .WithMessage("The user name cannot be longer 50 characters");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("The password cannot be empty.")
            .MinimumLength(8);

    }
}
