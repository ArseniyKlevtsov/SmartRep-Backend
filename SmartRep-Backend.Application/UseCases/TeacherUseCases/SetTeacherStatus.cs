using AutoMapper;
using SmartRep_Backend.Application.Dtos.TeacherDtos.Requests;
using SmartRep_Backend.Application.Dtos.TeacherDtos.Responses;
using SmartRep_Backend.Application.Dtos.UserDtos.Requests;
using SmartRep_Backend.Application.Exceptions;
using SmartRep_Backend.Application.Interfaces.UseCases.TeacherUseCases;
using SmartRep_Backend.Domain.IncludeStates;
using SmartRep_Backend.Domain.interfaces.Repositories;

namespace SmartRep_Backend.Application.UseCases.TeacherUseCases;
public class SetTeacherStatus : ISetTeacherStatus
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SetTeacherStatus(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task ExecuteAsync(Guid userId, CancellationToken cancellationToken)
    {
        var includeState = new UserIncludeState()
        {
            IncludeTeacherProfile = true,
        };

        var users = await _unitOfWork.Users.GetWithIncludeByPredicateAsync(u => u.Id  == userId, includeState, cancellationToken);

        var user = users.FirstOrDefault();

        if (user == null) 
        {
            throw new NotFoundExeption($"user with id {userId} not found");
        }

        user.TeacherProfile.StatusConfirmed = true;

        await _unitOfWork.TeacherProfiles.UpdateAsync(user.TeacherProfile, cancellationToken);
        await _unitOfWork.SaveAsync();
    }
}
