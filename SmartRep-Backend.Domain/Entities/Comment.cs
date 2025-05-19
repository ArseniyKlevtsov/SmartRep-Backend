using SmartRep_Backend.Domain.interfaces;

namespace SmartRep_Backend.Domain.Entities;
public class Comment: IEntity
{
    public Guid Id { get; set; }
    public string Message { get; set; }
    public string Urls { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid LessonId { get; set; }
    public Lesson Lesson { get; set; }
}
