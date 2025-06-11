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
    private readonly IGetMyCourses _getMyCourses;
    private readonly IUpdateCourse _updateCourse;
    private readonly ICreateCourse _createCourse;

    public CoursesController(IGetFSPCourses getFSPCourses, IGetMyCourses getMyCourses, IUpdateCourse updateCourse, ICreateCourse createCourse)
    {
        _getFSPCourses = getFSPCourses;
        _getMyCourses = getMyCourses;
        _updateCourse = updateCourse;
        _createCourse = createCourse;
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

    [HttpPost("createCourse")]
    public async Task<ActionResult> CreateCourse(CreateCourseRequest dto, CancellationToken cancellationToken)
    {
        await _createCourse.ExecuteAsync(dto, cancellationToken);
        return Ok();
    }

    [HttpPost("updateCourse")]
    public async Task<ActionResult> UpdateCourse(UpdateCourseRequest dto, CancellationToken cancellationToken)
    {
        await _updateCourse.ExecuteAsync(dto, cancellationToken);
        return Ok();
    }
}
