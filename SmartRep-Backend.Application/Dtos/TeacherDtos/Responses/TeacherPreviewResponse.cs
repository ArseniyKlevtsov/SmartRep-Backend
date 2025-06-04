namespace SmartRep_Backend.Application.Dtos.TeacherDtos.Responses;
public class TeacherPreviewResponse
{
    public Guid TeacherId { get; set; }
    public string TeacherName { get; set; }
    public string TeacherDescription { get; set; }
    public string TeacherAvatarUrl { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
