using Microsoft.AspNetCore.Mvc;
using SmartRep_Backend.Application.Dtos.LessonDtos.Requests;
using SmartRep_Backend.Application.Dtos.LessonDtos.Responses;
using SmartRep_Backend.Application.Interfaces.UseCases.Lessons;

namespace SmartRep_Backend.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LessonsController : ControllerBase
{
    private readonly IGetMyLessonsAsTeacher _getMyLessonsAsTeacher;

    public LessonsController(IGetMyLessonsAsTeacher getMyLessonsAsTeacher)
    {
        _getMyLessonsAsTeacher = getMyLessonsAsTeacher;
    }

    [HttpPost("getMyLessonsAsTeacher")]
    public async Task<ActionResult<GetMyLessonsResponse>> RegisterAsync(GetMyLessonsRequest dto, CancellationToken cancellationToken)
    {
        var userResponseDto = await _getMyLessonsAsTeacher.ExecuteAsync(dto, cancellationToken);
        return Ok(userResponseDto);
    }
}
