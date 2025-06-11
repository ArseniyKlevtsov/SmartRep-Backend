namespace SmartRep_Backend.Application.Dtos.Courses.Requests;
public class UpdateCourseRequest
{
    public Guid UserId { get; set; }
    public List<string> studentNames { get; set; }

    public Guid CourseId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }

}
