using Microsoft.AspNetCore.Mvc;
using SmartRep_Backend.Application.Dtos.TeacherDtos.Requests;
using SmartRep_Backend.Application.Dtos.TeacherDtos.Responses;
using SmartRep_Backend.Application.Interfaces.UseCases.TeacherUseCases;
using SmartRep_Backend.Application.UseCases.TeacherUseCases;

namespace SmartRep_Backend.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TeachersController : ControllerBase
{
    private readonly IGetFSPTeachers _getFSPTeachers;
    private readonly ISetTeacherStatus _setTeacherStatus;

    public TeachersController(IGetFSPTeachers getFSPTeachers, ISetTeacherStatus setTeacherStatus)
    {
        _getFSPTeachers = getFSPTeachers;
        _setTeacherStatus = setTeacherStatus;
    }

    [HttpPost("getFSPTeachersResponse")]
    public async Task<ActionResult<GetFSPTeachersResponse>> GetFSPTeachersResponse(GetFSPTeachersRequest dto, CancellationToken cancellationToken)
    {
        var response = await _getFSPTeachers.ExecuteAsync(dto, cancellationToken);
        return Ok(response);
    }

    [HttpPut("setTeacherStatus/{id}")]
    public async Task<ActionResult> SetTeacherStatus(Guid id, CancellationToken cancellationToken)
    {
        await _setTeacherStatus.ExecuteAsync(id, cancellationToken);
        return Ok();
    }
}
