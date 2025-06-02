using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRep_Backend.Application.Dtos.AuthDtos.Requests;
using SmartRep_Backend.Application.Dtos.AuthDtos.Responses;
using SmartRep_Backend.Application.Dtos.UserDtos.Requests;
using SmartRep_Backend.Application.Dtos.UserDtos.Responses;
using SmartRep_Backend.Application.Interfaces.UseCases.AuthUseCases;
using SmartRep_Backend.Application.Interfaces.UseCases.UserUseCases;
using SmartRep_Backend.Application.UseCases.AuthUseCases;

namespace SmartRep_Backend.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{

    private readonly IGetShortcutUserProfile _getShortcutUserProfile;

    public UsersController(IGetShortcutUserProfile getShortcutUserProfile)
    {
        _getShortcutUserProfile = getShortcutUserProfile;
    }

    [Authorize]
    [HttpPost("getShortcutUserProfile")]
    public async Task<ActionResult<ShortcutUserProfileResponse>> RegisterAsync(UserInfoRequest dto, CancellationToken cancellationToken)
    {
        var userResponseDto = await _getShortcutUserProfile.ExecuteAsync(dto, cancellationToken);

        Console.WriteLine(userResponseDto.AvatarUrl);
        Console.WriteLine(userResponseDto.Username);
        return Ok(userResponseDto);
    }
}
