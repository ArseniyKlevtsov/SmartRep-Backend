namespace SmartRep_Backend.Application.Dtos.Courses.Requests;
public class GetFSPCoursesRequest
{
    public string? NameFilter { get; set; }
    public int StartIndex { get; set; }
    public int? PageSize { get; set; }
}
