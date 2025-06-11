using AutoMapper;
using SmartRep_Backend.Application.Dtos.Courses.Requests;
using SmartRep_Backend.Application.Dtos.Courses.Responses;
using SmartRep_Backend.Application.Interfaces.UseCases.CourseUseCases;
using SmartRep_Backend.Domain.IncludeStates;
using SmartRep_Backend.Domain.interfaces.Repositories;

namespace SmartRep_Backend.Application.UseCases.CourseUseCases;
public class GetFullCourse : IGetFullCourse
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetFullCourse(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<FullCourseResponse> ExecuteAsync(CourseInfoRequest dto, CancellationToken cancellationToken)
    {
        var course = await _unitOfWork.Courses.GetByIdWithIncludeAsync(
            dto.CourseId,
            new CourseIncludeState
            {
                IncludeTeacherProfile = true,
                IncludeTeacherUser = true,
                IncludeStudents = true,
                IncludeStudentUsers = true
            },
            cancellationToken);

        if (course == null)
        {
            throw new ArgumentException($"Course with ID {dto.CourseId} was not found");
        }

        return _mapper.Map<FullCourseResponse>(course);
    }
}
