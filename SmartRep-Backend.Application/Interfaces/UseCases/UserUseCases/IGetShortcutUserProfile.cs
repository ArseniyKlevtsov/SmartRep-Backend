using SmartRep_Backend.Application.Dtos.UserDtos.Requests;
using SmartRep_Backend.Application.Dtos.UserDtos.Responses;

namespace SmartRep_Backend.Application.Interfaces.UseCases.UserUseCases;
public interface IGetShortcutUserProfile
{
    public Task<ShortcutUserProfileResponse> ExecuteAsync(UserInfoRequest dto, CancellationToken cancellationToken);
}
