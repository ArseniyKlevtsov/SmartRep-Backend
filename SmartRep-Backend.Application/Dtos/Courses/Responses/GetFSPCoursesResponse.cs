namespace SmartRep_Backend.Application.Dtos.Courses.Responses;
public class GetFSPCoursesResponse
{
    public List<CoursePreviewResponse> Courses { get; set; }
    public int TotalCount { get; set; }
}
