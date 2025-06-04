namespace SmartRep_Backend.Application.Dtos.UserDtos.Responses;
public class UserProfileResponse
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string AvatarUrl { get; set; }
    public string CreatedAt { get; set; }

    public string StudentDecription{ get; set; }

    public bool TeacherStatusConfirmed{ get; set; }
    public string TeacherDecription{ get; set; }
}
