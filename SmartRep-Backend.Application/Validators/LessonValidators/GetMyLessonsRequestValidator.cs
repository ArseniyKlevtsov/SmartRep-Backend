using FluentValidation;
using SmartRep_Backend.Application.Dtos.LessonDtos.Requests;

namespace SmartRep_Backend.Application.Validators.LessonValidators;
public class GetMyLessonsRequestValidator : AbstractValidator<GetMyLessonsRequest>
{
    public GetMyLessonsRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("The UsedId cannot be empty.");

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage("The StartDate cannot be empty.");

        RuleFor(x => x.EndDate)
            .NotEmpty()
            .WithMessage("The EndDate cannot be empty.");

        RuleFor(x => x.AsTeacher)
            .NotEmpty()
            .WithMessage("The AsTeacher cannot be empty.");
    }
}
