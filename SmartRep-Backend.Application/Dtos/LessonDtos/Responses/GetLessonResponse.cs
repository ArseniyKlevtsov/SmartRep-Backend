namespace SmartRep_Backend.Application.Dtos.LessonDtos.Responses;
public class GetLessonResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public DateTime StartTime { get; set; }
    public int DurationMinutes { get; set; }
    public bool PaymentStatus { get; set; }
    public string Status { get; set; }
}
