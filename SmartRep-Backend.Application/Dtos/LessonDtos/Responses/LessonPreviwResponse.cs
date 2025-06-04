namespace SmartRep_Backend.Application.Dtos.LessonDtos.Responses;
public class LessonPreviwResponse
{
    public Guid LessonId { get; set; }
    public string LessonName { get; set; }
    public double Price { get; set; }
    public int DurationMinutes { get; set; }
    public DateTime StartTime { get; set; }
    public bool PaymentStatus { get; set; }
    public string? Status { get; set; }

    public string CourseName { get; set; }
    public string CourseAvatar { get; set; }
}
