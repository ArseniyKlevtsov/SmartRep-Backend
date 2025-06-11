namespace SmartRep_Backend.Application.Dtos.Courses.Requests;
public class CreateCourseRequest
{
    public Guid UserId { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}
