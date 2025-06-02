using AutoMapper;
using SmartRep_Backend.Application.Dtos.AuthDtos.Responses;
using SmartRep_Backend.Application.Dtos.UserDtos.Requests;
using SmartRep_Backend.Application.Dtos.UserDtos.Responses;
using SmartRep_Backend.Application.Interfaces.UseCases.UserUseCases;
using SmartRep_Backend.Domain.interfaces.Repositories;
using System.Security.Authentication;

namespace SmartRep_Backend.Application.UseCases.UserUseCases;
public class GetShortcutUserProfile : IGetShortcutUserProfile
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetShortcutUserProfile (IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ShortcutUserProfileResponse> ExecuteAsync(UserInfoRequest dto, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(dto.UserId, cancellationToken);

        if (user == null)
        {
            throw new AuthenticationException($"user was not found");
        }

        var response = _mapper.Map<ShortcutUserProfileResponse>(user);

        return response;
    }
}
