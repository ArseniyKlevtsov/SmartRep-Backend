using SmartRep_Backend.Domain.interfaces;

namespace SmartRep_Backend.Domain.Entities;
public class Lesson: IEntity
{
    public Guid Id { get; set; }

    public double Name { get; set; }
    public double Description { get; set; }
    public double Price { get; set; }
    public DateTime StartTime { get; set; } = DateTime.UtcNow;
    public int DurationMinutes { get; set; } = 45;
    public bool PaymentStatus { get; set; }
    public string Status { get; set; }

    public DateTime EndTime => StartTime.AddMinutes(DurationMinutes);

    public Guid CourseId { get; set; }
    public Course Course { get; set; }

    public Guid TeacherId { get; set; }
    public User Teacher { get; set; }

    public Guid StudentId { get; set; }
    public User Student { get; set; }

    public List<Notification> Notifications { get; set; }
    public List<LessionTask> LessionTasks { get; set; }
}
