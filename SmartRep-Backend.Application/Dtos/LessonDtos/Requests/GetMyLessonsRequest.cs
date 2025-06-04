namespace SmartRep_Backend.Application.Dtos.LessonDtos.Requests;
public class GetMyLessonsRequest
{
    public Guid UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool AsTeacher { get; set; }
}
