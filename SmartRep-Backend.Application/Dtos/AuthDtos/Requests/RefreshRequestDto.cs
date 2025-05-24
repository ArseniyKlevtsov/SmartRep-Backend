namespace SmartRep_Backend.Application.Dtos.AuthDtos.Requests;
public class RefreshRequestDto
{
    public string? ExpiredAccessToken { get; set; }
    public string? RefreshToken { get; set; }
}
