using SmartRep_Backend.Domain.interfaces;

namespace SmartRep_Backend.Domain.Entities;

public class Course: IEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public string AvatarUrl { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }

    public Guid TeacherId { get; set; }
    public User Teacher { get; set; }

    public List<User> Students { get; set; } = new();
    public List<Lesson> Lessons { get; set; } = new();
}
