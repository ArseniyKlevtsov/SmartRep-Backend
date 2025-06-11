using SmartRep_Backend.Application.Dtos.Courses.Requests;

namespace SmartRep_Backend.Application.Interfaces.UseCases.CourseUseCases;
public interface IUpdateCourse
{
    Task ExecuteAsync(UpdateCourseRequest dto, CancellationToken cancellationToken);
}
