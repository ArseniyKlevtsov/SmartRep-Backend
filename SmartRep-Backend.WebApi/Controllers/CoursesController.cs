using Microsoft.AspNetCore.Mvc;
using SmartRep_Backend.Application.Dtos.Courses.Requests;
using SmartRep_Backend.Application.Dtos.Courses.Responses;
using SmartRep_Backend.Application.Interfaces.UseCases.CourseUseCases;
using SmartRep_Backend.Application.UseCases.CourseUseCases;

namespace SmartRep_Backend.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly IGetFSPCourses _getFSPCourses;
    private readonly IGetMyCourses _getMyCourses;

    public CoursesController(IGetFSPCourses getFSPCourses, IGetMyCourses getMyCourses)
    {
        _getFSPCourses = getFSPCourses;
        _getMyCourses = getMyCourses;
    }

    [HttpPost("getFSPCourses")]
    public async Task<ActionResult<GetFSPCoursesResponse>> GetFSPCourses(GetFSPCoursesRequest dto, CancellationToken cancellationToken)
    {
        var response = await _getFSPCourses.ExecuteAsync(dto, cancellationToken);
        return Ok(response);
    }

    [HttpPost("getMyCourses")]
    public async Task<ActionResult<GetFSPCoursesResponse>> GetMyCourses(GetMyCoursesRequest dto, CancellationToken cancellationToken)
    {
        var response = await _getMyCourses.ExecuteAsync(dto, cancellationToken);
        return Ok(response);
    }
}
