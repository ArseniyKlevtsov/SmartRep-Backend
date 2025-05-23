namespace SmartRep_Backend.Domain.interfaces.Repositories;
public interface IUnitOfWork : IDisposable
{
    ICommentRepository Comments { get; }
    ICourseRepository Courses { get; }
    ILessonRepository Lessons { get; }
    ILessonTaskRepository LessonTasks { get; }
    INotificationRepository Notifications { get; }
    IUserRepository Users { get; }

    Task SaveAsync();
}