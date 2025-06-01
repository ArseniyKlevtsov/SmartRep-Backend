using SmartRep_Backend.Domain.interfaces;

namespace SmartRep_Backend.Domain.Entities;

public class User: IEntity
{
    public Guid Id { get; set; }

    public string Username { get; set; } = "";
    public string PasswordHash { get; set; } = "";
    public string Salt { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }

    public string? AvatarUrl { get; set; }

    public Guid TeacherProfileId { get; set; }
    public TeacherProfile? TeacherProfile { get; set; }

    public Guid StudentProfileId { get; set; }
    public StudentProfile? StudentProfile { get; set; }

    public List<Notification>? Notifications { get; set; }
    public List<Comment>? Comments { get; set; }
}