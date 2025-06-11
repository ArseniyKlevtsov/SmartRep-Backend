using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.interfaces.Services;


namespace SmartRep_Backend.Infrastructure.Data;
public class DatabaseInitializer
{
    private readonly SmartRepDbContext _context;
    private readonly IPasswordService _passwordService;

    private List<Comment> _comments = new();
    private List<Course> _courses = new();
    private List<Lesson> _lessons = new();
    private List<LessonTask> _lessonTasks = new();
    private List<Notification> _notifications = new();
    private List<TeacherProfile> _teacherProfiles = new();
    private List<StudentProfile> _studentProfiles = new();
    private List<User> _users = new();

    public DatabaseInitializer(SmartRepDbContext context, IPasswordService passwordService)
    {
        _context = context;
        _passwordService = passwordService;
    }

    public void Initialize()
    {
        Console.WriteLine("IN");
        if(!AnyRecordsExist())
        {
            Console.WriteLine("Initialize start\n");

            Console.WriteLine("SeedUsersAndProfiles\n");
            SeedUsersAndProfiles();

            Console.WriteLine("SeedCourses\n");
            SeedCourses();

            Console.WriteLine("SeedLessons\n");
            SeedLessons();

            Console.WriteLine("SeedLessonTasks\n");
            SeedLessonTasks();

            Console.WriteLine("Saving in db\n");
            SaveChanges();

            Console.WriteLine("Initialize end\n");
        }
    }

    private bool AnyRecordsExist()
    {
        return _context.Comments.Any() ||
               _context.Courses.Any() ||
               _context.Lessons.Any() ||
               _context.LessonTasks.Any() ||
               _context.Notifications.Any() ||
               _context.StudentProfiles.Any() ||
               _context.TeacherProfiles.Any() ||
               _context.Users.Any();
    }
    
    private void SeedUsersAndProfiles()
    {
        for (int i = 1; i <= 10; i++)
        {
            var password = "password" + i;
            var (hash, salt) = _passwordService.CreatePasswordHash(password);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = $"user{i}",
                PasswordHash = hash,
                Salt = salt,
                CreatedAt = DateTime.UtcNow,
                FullName = $"User {i}",
                Email = $"user{i}@example.com",
                Phone = $"12345678{i}",
                TeacherProfileId = Guid.NewGuid(),
                StudentProfileId = Guid.NewGuid()
            };

            user.AvatarUrl = $"/static-files/user-avatars/{user.Id}.png";


            var teacherProfile = new TeacherProfile
            {
                Id = user.TeacherProfileId,
                AboutMe = $"About teacher {user.Username}",
                UserId = user.Id,
                StatusConfirmed = false,
            };

            var studentProfile = new StudentProfile
            {
                Id = user.StudentProfileId,
                AboutMe = $"About student {user.Username}",
                UserId = user.Id
            };

            _users.Add(user);
            _teacherProfiles.Add(teacherProfile);
            _studentProfiles.Add(studentProfile);
        }
    }

    private void SeedCourses()
    {
        for (int i = 1; i <= 5; i++)
        {
            var course = new Course
            {
                Id = Guid.NewGuid(),
                Description = $"Description for course {i}",
                Name = $"Course {i}",
                Price = 100 + (i * 20),
                TeacherProfileId = GetRandomTeacherProfileId()
            };

            course.AvatarUrl = $"/static-files/course-avatars/{course.Id}.png";

            _courses.Add(course);
        }
    }

    private Guid GetRandomTeacherProfileId()
    {
        return _teacherProfiles[new Random().Next(_teacherProfiles.Count)].Id;
    }

    private void SeedLessons()
    {
        var random = new Random();

        foreach (var course in _courses)
        {

            var availableStudents = _studentProfiles.Where(sp => sp.UserId != Guid.Empty).ToList();

            for (int i = 1; i <= 3; i++)
            {
                var studentProfile = availableStudents[random.Next(availableStudents.Count)];

                var lesson = new Lesson
                {
                    Id = Guid.NewGuid(),
                    Name = $"Lesson {i}",
                    Description = $"Description for Lesson {i} of course {course.Description}",
                    Price = 50 + (i * 10),
                    StartTime = DateTime.UtcNow.AddDays(i),
                    DurationMinutes = 45,
                    PaymentStatus = false,
                    Status = "Scheduled",
                    CourseId = course.Id,
                    StudentProfileId = studentProfile.Id
                };

                _lessons.Add(lesson);
            }
        }
    }

    private void SeedLessonTasks()
    {
        foreach (var lesson in _lessons)
        {
            for (int i = 1; i <= 2; i++)
            {
                var lessonTask = new LessonTask
                {
                    Id = Guid.NewGuid(),
                    Name = $"Task {i} for {lesson.Name}",
                    Description = $"Description for Task {i} of lesson {lesson.Name}",
                    IsSolved = false,
                    Grade = 0,
                    LessonId = lesson.Id
                };
                lessonTask.Url = $"/static-files/lesson-tasks/{lessonTask.Id}.pdf";
                _lessonTasks.Add(lessonTask);
            }
        }
    }

    private void SaveChanges()
    {

        _context.Users.AddRange(_users);
        _context.TeacherProfiles.AddRange(_teacherProfiles);
        _context.StudentProfiles.AddRange(_studentProfiles);
        _context.Courses.AddRange(_courses);
        _context.Lessons.AddRange(_lessons);
        _context.LessonTasks.AddRange(_lessonTasks);
        _context.SaveChanges();
    }
}
