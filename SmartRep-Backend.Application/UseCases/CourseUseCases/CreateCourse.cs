using AutoMapper;
using SmartRep_Backend.Application.Dtos.Courses.Requests;
using SmartRep_Backend.Application.Interfaces.UseCases.CourseUseCases;
using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;
using SmartRep_Backend.Domain.interfaces.Repositories;

namespace SmartRep_Backend.Application.UseCases.CourseUseCases;
public class CreateCourse : ICreateCourse
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCourse(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task ExecuteAsync(CreateCourseRequest dto, CancellationToken cancellationToken)
    {
        var course = _mapper.Map<Course>(dto);

        var user = await _unitOfWork.Users.GetByIdWithIncludeAsync(dto.UserId,
            new UserIncludeState() { IncludeTeacherProfile = true }, cancellationToken);

        if (user == null)
        {
            throw new ArgumentException($"User with ID {dto.UserId} was not found");
        }

        if (user.TeacherProfile == null)
        {
            throw new InvalidOperationException($"User with ID {dto.UserId} is not a teacher");
        }

        course.TeacherProfileId = user.TeacherProfile.Id;

        await _unitOfWork.Courses.AddAsync(course, cancellationToken);
        await _unitOfWork.SaveAsync();
    }

}
