using AutoMapper;
using SmartRep_Backend.Application.Dtos.Courses.Requests;
using SmartRep_Backend.Application.Dtos.Courses.Responses;
using SmartRep_Backend.Application.Interfaces.UseCases.CourseUseCases;
using SmartRep_Backend.Domain.interfaces.Repositories;

namespace SmartRep_Backend.Application.UseCases.CourseUseCases;
public class GetFSPCourses : IGetFSPCourses
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetFSPCourses(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<GetFSPCoursesResponse> ExecuteAsync(GetFSPCoursesRequest dto, CancellationToken cancellationToken)
    {

        var courses = await _unitOfWork.Courses.GetWithTeacherAndStudentsAsync(cancellationToken);

        if (!string.IsNullOrEmpty(dto.NameFilter))
        {
            courses = courses.Where(course => course.Name.Contains(dto.NameFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        var totalCount = courses.Count();
        var pagedCourses = courses.Skip(dto.StartIndex).Take(dto.PageSize ?? totalCount).ToList();

        var response = new GetFSPCoursesResponse
        {
            TotalCount = totalCount,
            Courses = _mapper.Map<List<CoursePreviewResponse>>(pagedCourses) 
        };

        return response;
    }
}
