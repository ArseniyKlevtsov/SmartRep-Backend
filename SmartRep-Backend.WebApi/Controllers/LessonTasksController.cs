using Microsoft.AspNetCore.Mvc;
using SmartRep_Backend.Application.Dtos.LessonDtos.Requests;
using SmartRep_Backend.Application.Dtos.LessonTasksDtos.Responses;
using SmartRep_Backend.Application.Interfaces.UseCases.LessonTaskUseCases;

namespace SmartRep_Backend.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonTasksController : ControllerBase
{
    private readonly IGetLessonTasks _getLessonTasks;

    public LessonTasksController(IGetLessonTasks getLessonTasks)
    {
        _getLessonTasks = getLessonTasks;
    }

    [HttpPost("getLessonTasks")]
    public async Task<ActionResult<LessonTasksResponse>> GetLessonTasks(GetLessonRequest dto, CancellationToken cancellationToken)
    {
        var response = await _getLessonTasks.ExecuteAsync(dto, cancellationToken);
        return Ok(response);
    }
}
