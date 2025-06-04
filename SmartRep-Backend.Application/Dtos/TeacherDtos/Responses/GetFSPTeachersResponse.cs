namespace SmartRep_Backend.Application.Dtos.TeacherDtos.Responses;
public class GetFSPTeachersResponse
{
    public List<TeacherPreviewResponse> Teachers { get; set; }
    public int TotalCount { get; set; }
}
