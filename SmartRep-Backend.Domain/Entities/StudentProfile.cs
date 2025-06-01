using SmartRep_Backend.Domain.interfaces;

namespace SmartRep_Backend.Domain.Entities;
public class StudentProfile : IEntity
{
    public Guid Id { get; set; }
    public string AboutMe { get; set; } = "";

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public List<Lesson>? Lessons { get; set; }
    public List<Course>? Courses { get; set; }
}
