namespace SmartRep_Backend.Application.Dtos.CommentDtos;
public class CommentResponse
{
    public Guid Id { get; set; }
    public string? Message { get; set; }
    public string? FileUrl { get; set; }

    public string? UserName { get; set; }
    public string? UserAvatarUrl { get; set; }
}
