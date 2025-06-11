using SmartRep_Backend.Application.Dtos.Courses.Requests;
using SmartRep_Backend.Application.Dtos.Courses.Responses;

namespace SmartRep_Backend.Application.Interfaces.UseCases.CourseUseCases;
public interface IGetFullCourse
{
    Task<FullCourseResponse> ExecuteAsync(CourseInfoRequest dto, CancellationToken cancellationToken);
}
