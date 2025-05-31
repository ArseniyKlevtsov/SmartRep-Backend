using SmartRep_Backend.Application.Dtos.AuthDtos.Requests;
using SmartRep_Backend.Application.Dtos.AuthDtos.Responses;
using SmartRep_Backend.Application.Interfaces.Services;
using SmartRep_Backend.Application.Interfaces.UseCases.AuthUseCases;
using SmartRep_Backend.Domain.interfaces.Repositories;
using SmartRep_Backend.Domain.interfaces.Services;
using System.Security.Authentication;
using System.Security.Claims;

namespace SmartRep_Backend.Application.UseCases.AuthUseCases;
public class Login : ILoginUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;
    private readonly IPasswordService _passwordService;

    public Login(IUnitOfWork unitOfWork, ITokenService tokenService, IPasswordService passwordService)
    {
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
        _passwordService = passwordService;
    }

    public async Task<LoginResponseDto> ExecuteAsync(LoginRequestDto loginRequestDto,  CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetByPredicateAsync(u => u.Username == loginRequestDto.Username, cancellationToken);

        var userAuthenticated = user != null &&  _passwordService.VerifyPassword(loginRequestDto.Password!, user.PasswordHash, user.Salt);
        if (userAuthenticated == false)
        {
            throw new AuthenticationException($"user {loginRequestDto.Username} was not found or the password is incorrect");
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username)
        };

        var token =  _tokenService.GenerateJwtToken(claims);

        var tokensRespone = new LoginResponseDto()
        {
            AccessToken = token,
        };

        return tokensRespone;
    }
}
