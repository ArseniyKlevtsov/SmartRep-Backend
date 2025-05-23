using SmartRep_Backend.Domain.interfaces.Repositories;
using SmartRep_Backend.Infrastructure.Data;

namespace SmartRep_Backend.Infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private bool disposed = false;
    private readonly SmartRepDbContext _context;

    private ICommentRepository? _commentRepository;
    private ICourseRepository? _courseRepository;
    private ILessonRepository? _lessonRepository;
    private ILessonTaskRepository? _lessonTaskRepository;
    private INotificationRepository? _notificationRepository;
    private IUserRepository? _userRepository;

    public UnitOfWork(SmartRepDbContext context)
    {
        _context = context;
    }

    public ICommentRepository Comments
    {
        get
        {
            if (_commentRepository == null)
                _commentRepository = new CommentRepository(_context);
            return _commentRepository;
        }
    }

    public ICourseRepository Courses
    {
        get
        {
            if (_courseRepository == null)
                _courseRepository = new CourseRepository(_context);
            return _courseRepository;
        }
    }

    public ILessonRepository Lessons
    {
        get
        {
            if (_lessonRepository == null)
                _lessonRepository = new LessonRepository(_context);
            return _lessonRepository;
        }
    }

    public ILessonTaskRepository LessonTasks
    {
        get
        {
            if (_lessonTaskRepository == null)
                _lessonTaskRepository = new LessonTaskRepository(_context);
            return _lessonTaskRepository;
        }
    }

    public INotificationRepository Notifications
    {
        get
        {
            if (_notificationRepository == null)
                _notificationRepository = new NotificationRepository(_context);
            return _notificationRepository;
        }
    }

    public IUserRepository Users
    {
        get
        {
            if (_userRepository == null)
                _userRepository = new UserRepository(_context);
            return _userRepository;
        }
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
