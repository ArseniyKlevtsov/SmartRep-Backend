using SmartRep_Backend.Application.Dtos.Courses.Requests;
using SmartRep_Backend.Application.Dtos.Courses.Responses;

namespace SmartRep_Backend.Application.Interfaces.UseCases.CourseUseCases;
public interface IGetFSPCourses
{
    Task<GetFSPCoursesResponse> ExecuteAsync(GetFSPCoursesRequest dto, CancellationToken cancellationToken);
}
