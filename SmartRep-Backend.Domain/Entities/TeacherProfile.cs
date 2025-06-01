using SmartRep_Backend.Domain.interfaces;

namespace SmartRep_Backend.Domain.Entities;
public class TeacherProfile : IEntity
{
    public Guid Id { get; set; } = new Guid();
    public string? AboutMe { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public List<Course>? Courses { get; set; }
}
