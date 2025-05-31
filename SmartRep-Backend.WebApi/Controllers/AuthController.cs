using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRep_Backend.Application.Dtos.AuthDtos.Requests;
using SmartRep_Backend.Application.Dtos.AuthDtos.Responses;
using SmartRep_Backend.Application.Interfaces.UseCases.AuthUseCases;
using System.Security.Claims;

namespace SmartRep_Backend.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ILoginUseCase _login;
    private readonly IRegisterUseCase _register;

    public AuthController(ILoginUseCase login, IRegisterUseCase register)
    {
        _login = login;
        _register = register;
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegisterResonseDto>> RegisterAsync(RegisterRequestDto registerRequestDto, CancellationToken cancellationToken)
    {
        var userResponseDto = await _register.ExecuteAsync(registerRequestDto, cancellationToken);

        return Ok(userResponseDto);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDto>> LoginAsync(LoginRequestDto loginRequestDto, CancellationToken cancellationToken)
    {
        var tokenResponse = await _login.ExecuteAsync(loginRequestDto, cancellationToken);
        return Ok(tokenResponse);
    }

    [HttpGet("protected")]
    [Authorize] // Требует аутентификации
    public IActionResult ProtectedEndpoint()
    {

        return Ok(new
        {
            Message = "You have access to protected data!",
        });
    }
}
