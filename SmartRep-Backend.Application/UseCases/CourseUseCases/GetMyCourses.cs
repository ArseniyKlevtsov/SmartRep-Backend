using AutoMapper;
using SmartRep_Backend.Application.Dtos.Courses.Requests;
using SmartRep_Backend.Application.Dtos.Courses.Responses;
using SmartRep_Backend.Application.Interfaces.UseCases.CourseUseCases;
using SmartRep_Backend.Domain.interfaces.Repositories;

namespace SmartRep_Backend.Application.UseCases.CourseUseCases;
public class GetMyCourses : IGetMyCourses
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetMyCourses(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetFSPCoursesResponse> ExecuteAsync(GetMyCoursesRequest dto, CancellationToken cancellationToken)
    {
        var courses = await _unitOfWork.Courses.GetWithTeacherAsync(cancellationToken);

        var totalCount = courses.Count();

        courses = courses.Where(course => course.TeacherProfile.UserId == dto.UserId).ToList();

        var response = new GetFSPCoursesResponse
        {
            TotalCount = totalCount,
            Courses = _mapper.Map<List<CoursePreviewResponse>>(courses)
        };

        return response;
    }
}
