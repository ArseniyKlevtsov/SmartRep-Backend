using SmartRep_Backend.Domain.interfaces;

namespace SmartRep_Backend.Domain.Entities;

public class Course: IEntity
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
    public string? AvatarUrl { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }

    public Guid TeacherProfileId { get; set; }
    public TeacherProfile? TeacherProfile { get; set; }

    public List<StudentProfile> Students { get; set; } = new();
    public List<Lesson> Lessons { get; set; } = new();
}
