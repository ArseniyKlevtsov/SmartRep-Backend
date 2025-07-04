﻿using Microsoft.AspNetCore.Authorization;
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
    private readonly ILogin _login;
    private readonly IRegister _register;

    public AuthController(ILogin login, IRegister register)
    {
        _login = login;
        _register = register;
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegisterResonseDto>> RegisterAsync(RegisterRequestDto registerRequestDto, CancellationToken cancellationToken)
    {
        var response = await _register.ExecuteAsync(registerRequestDto, cancellationToken);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDto>> LoginAsync(LoginRequestDto loginRequestDto, CancellationToken cancellationToken)
    {
        var response = await _login.ExecuteAsync(loginRequestDto, cancellationToken);

        return Ok(response);
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
