using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRep_Backend.Application.Dtos.UserDtos.Requests;
using SmartRep_Backend.Application.Dtos.UserDtos.Responses;
using SmartRep_Backend.Application.Interfaces.UseCases.UserUseCases;

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
        return Ok(userResponseDto);
    }
}
