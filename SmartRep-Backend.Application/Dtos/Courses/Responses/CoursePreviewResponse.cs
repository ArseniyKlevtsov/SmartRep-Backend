namespace SmartRep_Backend.Application.Dtos.Courses.Responses;
public class CoursePreviewResponse
{
    public Guid CourseId { get; set; }
    public string CourseName { get; set; }
    public string CourseDescription { get; set; }
    public string CourseAvatarUrl { get; set; }
    public double Price { get; set; }
    public string TeacherName { get; set; }
    public string TeacherAvatarUrl { get; set; }
}
