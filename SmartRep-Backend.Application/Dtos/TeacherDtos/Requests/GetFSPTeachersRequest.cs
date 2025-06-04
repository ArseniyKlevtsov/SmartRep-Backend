namespace SmartRep_Backend.Application.Dtos.TeacherDtos.Requests;
public class GetFSPTeachersRequest
{
    public string? TextFilter { get; set; }
    public int StartIndex { get; set; }
    public int? PageSize { get; set; }
}
