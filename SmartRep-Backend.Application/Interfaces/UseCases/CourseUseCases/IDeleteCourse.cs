namespace SmartRep_Backend.Application.Interfaces.UseCases.CourseUseCases;
public interface IDeleteCourse
{
    Task ExecuteAsync(Guid courseId, CancellationToken cancellationToken);
}
