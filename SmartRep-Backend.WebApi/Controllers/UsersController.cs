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
    private readonly IGetUserProfile _getUserProfile;

    public UsersController(IGetShortcutUserProfile getShortcutUserProfile, IGetUserProfile getUserProfile)
    {
        _getShortcutUserProfile = getShortcutUserProfile;
        _getUserProfile = getUserProfile;
    }

    [Authorize]
    [HttpPost("getShortcutUserProfile")]
    public async Task<ActionResult<ShortcutUserProfileResponse>> GetShortcutUserProfile(UserInfoRequest dto, CancellationToken cancellationToken)
    {
        var userResponseDto = await _getShortcutUserProfile.ExecuteAsync(dto, cancellationToken);
        return Ok(userResponseDto);
    }    
    

    [HttpPost("getUserProfile")]
    public async Task<ActionResult<UserProfileResponse>> GetUserProfileResponse(UserInfoRequest dto, CancellationToken cancellationToken)
    {
        var userResponseDto = await _getUserProfile.ExecuteAsync(dto, cancellationToken);
        return Ok(userResponseDto);
    }
}
