using SmartRep_Backend.Application.Interfaces.UseCases.AuthUseCases;
using SmartRep_Backend.Application.Interfaces.UseCases.CommentUseCases;
using SmartRep_Backend.Application.Interfaces.UseCases.CourseUseCases;
using SmartRep_Backend.Application.Interfaces.UseCases.Lessons;
using SmartRep_Backend.Application.Interfaces.UseCases.LessonTaskUseCases;
using SmartRep_Backend.Application.Interfaces.UseCases.TeacherUseCases;
using SmartRep_Backend.Application.Interfaces.UseCases.UserUseCases;
using SmartRep_Backend.Application.UseCases.AuthUseCases;
using SmartRep_Backend.Application.UseCases.CommentUseCases;
using SmartRep_Backend.Application.UseCases.CourseUseCases;
using SmartRep_Backend.Application.UseCases.Lessons;
using SmartRep_Backend.Application.UseCases.LessonTasks;
using SmartRep_Backend.Application.UseCases.TeacherUseCases;
using SmartRep_Backend.Application.UseCases.UserUseCases;

namespace SmartRep_Backend.WebApi.Extentions.ServiceRegistrators;

public static class UseCasesRegistrator
{
    public static IServiceCollection AddUseCases(this IServiceCollection services, IConfiguration configuration)
    {
        // Auth
        services.AddTransient<IRegister, Register>();
        services.AddTransient<ILogin, Login>();

        // Users
        services.AddTransient<IGetShortcutUserProfile, GetShortcutUserProfile>();
        services.AddTransient<IGetUserProfile, GetUserProfile>();

        // Courses
        services.AddTransient<IGetFSPCourses, GetFSPCourses>();

        // Teachers
        services.AddTransient<IGetFSPTeachers, GetFSPTeachers>();

        // Lessons
        services.AddTransient<IGetMyLessons, GetMyLessons>();
        services.AddTransient<IGetLesson, GetLesson>();

        // LessonTasks
        services.AddTransient<IGetLessonTasks, GetLessonTasks>();

        //Comments
        services.AddTransient<IGetLessonComents, GetLessonComents>();

        return services;
    }
}
