using AutoMapper;
using SmartRep_Backend.Application.Dtos.UserDtos.Requests;
using SmartRep_Backend.Application.Dtos.UserDtos.Responses;
using SmartRep_Backend.Application.Exceptions;
using SmartRep_Backend.Application.Interfaces.UseCases.UserUseCases;
using SmartRep_Backend.Domain.IncludeStates;
using SmartRep_Backend.Domain.interfaces.Repositories;

namespace SmartRep_Backend.Application.UseCases.UserUseCases;
public class GetUserProfile : IGetUserProfile
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserProfile(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserProfileResponse> ExecuteAsync(UserInfoRequest dto, CancellationToken cancellationToken)
    {
        var includeState = new UserIncludeState()
        {
            IncludeStudentProfile = true,
            IncludeTeacherProfile = true,
        };

        var users = await _unitOfWork.Users.GetWithIncludeByPredicateAsync(u => u.Id == dto.UserId, includeState, cancellationToken);
        var user = users.FirstOrDefault();
        if (user == null)
        {
            throw new NotFoundExeption($"user was not found");
        }

        var response = _mapper.Map<UserProfileResponse>(user);

        return response;
    }
}
