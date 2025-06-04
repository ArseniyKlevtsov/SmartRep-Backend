using Microsoft.AspNetCore.Mvc;
using SmartRep_Backend.Application.Dtos.TeacherDtos.Requests;
using SmartRep_Backend.Application.Dtos.TeacherDtos.Responses;
using SmartRep_Backend.Application.Interfaces.UseCases.TeacherUseCases;

namespace SmartRep_Backend.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TeachersController : ControllerBase
{
    private readonly IGetFSPTeachers _getFSPTeachers;

    public TeachersController(IGetFSPTeachers getFSPTeachers)
    {
        _getFSPTeachers = getFSPTeachers;
    }

    [HttpPost("getFSPTeachersResponse")]
    public async Task<ActionResult<GetFSPTeachersResponse>> RegisterAsync(GetFSPTeachersRequest dto, CancellationToken cancellationToken)
    {
        var userResponseDto = await _getFSPTeachers.ExecuteAsync(dto, cancellationToken);
        return Ok(userResponseDto);
    }
}
