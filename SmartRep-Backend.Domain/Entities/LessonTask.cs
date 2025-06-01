using SmartRep_Backend.Domain.interfaces;

namespace SmartRep_Backend.Domain.Entities;
public class LessonTask: IEntity
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public bool IsSolved { get; set; }
    public int Grade { get; set; }

    public Guid LessonId { get; set; }
    public Lesson? Lesson { get; set; }
}
