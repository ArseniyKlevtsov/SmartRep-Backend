using Microsoft.AspNetCore.Mvc;
using SmartRep_Backend.Application.Dtos.Courses.Requests;
using SmartRep_Backend.Application.Dtos.Courses.Responses;
using SmartRep_Backend.Application.Interfaces.UseCases.CourseUseCases;

namespace SmartRep_Backend.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly IGetFSPCourses _getFSPCourses;

    public CoursesController(IGetFSPCourses getFSPCourses)
    {
        _getFSPCourses = getFSPCourses;
    }

    [HttpPost("getFSPCoursesResponse")]
    public async Task<ActionResult<GetFSPCoursesResponse>> RegisterAsync(GetFSPCoursesRequest dto, CancellationToken cancellationToken)
    {
        var userResponseDto = await _getFSPCourses.ExecuteAsync(dto, cancellationToken);
        return Ok(userResponseDto);
    }
}
