using SmartRep_Backend.Domain.interfaces;

namespace SmartRep_Backend.Domain.Entities;
public class Notification : IEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } 
    public string Message { get; set; } 
    public DateTime TriggerTime { get; set; }
    public bool IsRead { get; set; }
    public string Type { get; set; } 

    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid? LessonId { get; set; }
    public Lesson? Lesson { get; set; }
}
