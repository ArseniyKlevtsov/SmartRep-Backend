using FluentValidation;
using SmartRep_Backend.Application.Dtos.Courses.Requests;

namespace SmartRep_Backend.Application.Validators.CourseValidators;
public class GetFSPCoursesRequestValidator : AbstractValidator<GetFSPCoursesRequest>
{
    public GetFSPCoursesRequestValidator()
    {
        RuleFor(x => x.NameFilter)
            .NotEmpty()
            .WithMessage("The username cannot be empty.")
            .MaximumLength(50)
            .WithMessage("The NameFilter name cannot be longer 50 characters");

        RuleFor(x => x.StartIndex)
            .NotEmpty()
            .WithMessage("The StartIndex cannot be empty.");
    }
}
