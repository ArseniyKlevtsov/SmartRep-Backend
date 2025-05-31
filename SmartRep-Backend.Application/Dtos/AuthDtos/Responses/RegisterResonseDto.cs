namespace SmartRep_Backend.Application.Dtos.AuthDtos.Responses;
public class RegisterResonseDto
{
    public Guid? Id { get; set; }
    public string? UserName { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? AboutMe { get; set; }
    public string? AvatarUrl { get; set; }
}
