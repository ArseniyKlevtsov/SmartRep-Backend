using Microsoft.AspNetCore.Mvc;
using SmartRep_Backend.Application.Dtos.LessonDtos.Requests;
using SmartRep_Backend.Application.Dtos.LessonDtos.Responses;
using SmartRep_Backend.Application.Interfaces.UseCases.Lessons;

namespace SmartRep_Backend.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LessonsController : ControllerBase
{
    private readonly IGetMyLessons _getMyLessons;
    private readonly IGetLesson _getLesson;

    public LessonsController(IGetMyLessons getMyLessonsAsTeacher, IGetLesson getLesson)
    {
        _getMyLessons = getMyLessonsAsTeacher;
        _getLesson = getLesson;
    }

    [HttpPost("getMyLessons")]
    public async Task<ActionResult<GetMyLessonsResponse>> GetMyLessons(GetMyLessonsRequest dto, CancellationToken cancellationToken)
    {
        var response = await _getMyLessons.ExecuteAsync(dto, cancellationToken);
        return Ok(response);
    }

    [HttpPost("getLesson")]
    public async Task<ActionResult<GetLessonResponse>> GetLesson(GetLessonRequest dto, CancellationToken cancellationToken)
    {
        var response = await _getLesson.ExecuteAsync(dto, cancellationToken);
        return Ok(response);
    }
}
