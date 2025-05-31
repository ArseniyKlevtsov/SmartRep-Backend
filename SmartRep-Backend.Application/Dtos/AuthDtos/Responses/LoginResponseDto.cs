namespace SmartRep_Backend.Application.Dtos.AuthDtos.Responses;
public class LoginResponseDto
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}
