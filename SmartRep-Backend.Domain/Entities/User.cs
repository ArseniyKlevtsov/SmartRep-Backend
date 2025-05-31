using SmartRep_Backend.Domain.interfaces;

namespace SmartRep_Backend.Domain.Entities;

public class User: IEntity
{
    public Guid Id { get; set; }

    public string Username { get; set; } = "";
    public string PasswordHash { get; set; } = "";
    public string Salt { get; set; } = "";

    public string FullName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string AboutMe { get; set; } = "";
    public string AvatarUrl { get; set; } = "";

    public List<Course> CoursesAsTeacher { get; set; } = new List<Course>();
    public List<Course> CoursesAsStudent { get; set; } = new List<Course>();

    public List<Lesson> LessonsAsTeacher { get; set; } = new List<Lesson>();
    public List<Lesson> LessonsAsStudent { get; set; } = new List<Lesson>();

    public List<Notification> Notifications { get; set; } = new List<Notification>();

    public List<Comment> Comments { get; set; } = new List<Comment>();
}