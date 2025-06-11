namespace SmartRep_Backend.Application.Dtos.Courses.Requests;
public class GetMyCoursesRequest
{
    public Guid UserId { get; set; }
    public bool AsTeacher { get; set; }
}
