using SmartRep_Backend.Application.Dtos.Courses.Requests;

namespace SmartRep_Backend.Application.Interfaces.UseCases.CourseUseCases;
public interface ICreateCourse
{
    Task ExecuteAsync(CreateCourseRequest dto, CancellationToken cancellationToken);
}
