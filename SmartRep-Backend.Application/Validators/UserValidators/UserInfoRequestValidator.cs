using FluentValidation;
using SmartRep_Backend.Application.Dtos.UserDtos.Requests;

namespace SmartRep_Backend.Application.Validators.UserValidators;
public class UserInfoRequestValidator : AbstractValidator<UserInfoRequest>
{
    public UserInfoRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("The UserId cannot be empty.");
    }
}
