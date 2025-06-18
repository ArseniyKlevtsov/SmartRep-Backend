namespace SmartRep_Backend.Application.Interfaces.UseCases.TeacherUseCases;
public interface ISetTeacherStatus
{
    Task ExecuteAsync(Guid userId, CancellationToken cancellationToken);
}
