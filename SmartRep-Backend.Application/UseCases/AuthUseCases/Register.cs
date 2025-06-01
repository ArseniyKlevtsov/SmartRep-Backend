using AutoMapper;
using SmartRep_Backend.Application.Dtos.AuthDtos.Requests;
using SmartRep_Backend.Application.Dtos.AuthDtos.Responses;
using SmartRep_Backend.Application.Exceptions;
using SmartRep_Backend.Application.Interfaces.UseCases.AuthUseCases;
using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.interfaces.Repositories;
using SmartRep_Backend.Domain.interfaces.Services;

namespace SmartRep_Backend.Application.UseCases.AuthUseCases;
public class Register : IRegisterUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPasswordService _passwordService;

    public Register(IUnitOfWork unitOfWork, IPasswordService passwordService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _passwordService = passwordService;

    }

    public async Task<RegisterResonseDto> ExecuteAsync(RegisterRequestDto registerRequestDto, CancellationToken cancellationToken)
    {
        var name = registerRequestDto.Username!;
        var isUserExist = await IsUserExsistAsync(name, cancellationToken);
        if (isUserExist)
        {
            throw new AlreadyExistsException($"User with this username:{name} already exists");
        }
        try
        {
            var (hash, salt) = _passwordService.CreatePasswordHash(registerRequestDto.Password);

            var user = new User()
            {
                Username = name,
                PasswordHash = hash,
                Salt = salt,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Users.AddAsync(user, cancellationToken);
            await _unitOfWork.SaveAsync();

        }
        catch (Exception)
        {
            throw new ExecutionFailedExeption($"Failed to register user");
        }

        var createdUser = await _unitOfWork.Users.GetByPredicateAsync(u => u.Username == name, cancellationToken);
        
        return _mapper.Map<RegisterResonseDto>(createdUser);
    }

    private async Task<bool> IsUserExsistAsync(string userName, CancellationToken cancellationToken)
    {
        var existedUser = await _unitOfWork.Users.GetByPredicateAsync(u => u.Username == userName, cancellationToken);
        if (existedUser == null)
        {
            return false;
        }
        return true;
    }
}
