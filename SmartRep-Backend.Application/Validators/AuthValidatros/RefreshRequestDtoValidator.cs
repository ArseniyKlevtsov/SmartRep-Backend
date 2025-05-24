using FluentValidation;
using SmartRep_Backend.Application.Dtos.AuthDtos.Requests;

namespace SmartRep_Backend.Application.Validators.AuthValidatros;
public class RefreshRequestDtoValidator : AbstractValidator<RefreshRequestDto>
{
    public RefreshRequestDtoValidator()
    {
        RuleFor(x => x.ExpiredAccessToken)
            .NotEmpty()
            .WithMessage("The ExpiredAccessToken cannot be empty.");

        RuleFor(x => x.RefreshToken)
            .NotEmpty()
            .WithMessage("The RefreshToken cannot be empty.");
    }
}
