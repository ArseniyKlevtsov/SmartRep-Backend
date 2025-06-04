using SmartRep_Backend.Application.Dtos.UserDtos.Requests;
using SmartRep_Backend.Application.Dtos.UserDtos.Responses;
using SmartRep_Backend.Application.UseCases.UserUseCases;

namespace SmartRep_Backend.Application.Interfaces.UseCases.UserUseCases;
public interface IGetUserProfile
{
    Task<UserProfileResponse> ExecuteAsync(UserInfoRequest dto, CancellationToken cancellationToken);
}
