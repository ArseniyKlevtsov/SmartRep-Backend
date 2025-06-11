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
    private readonly IDeleteCourse _deleteCourse;
    private readonly IGetFullCourse _getFullCourse;


    public CoursesController(
        IGetFSPCourses getFSPCourses,
        IGetMyCourses getMyCourses,
        IUpdateCourse updateCourse,
        ICreateCourse createCourse,
        IDeleteCourse deleteCourse,
        IGetFullCourse getFullCourse)
    {
        _getFSPCourses = getFSPCourses;
        _getMyCourses = getMyCourses;
        _updateCourse = updateCourse;
        _createCourse = createCourse;
        _deleteCourse = deleteCourse;
        _getFullCourse = getFullCourse;
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

    [HttpPost("deleteCourse")]
    public async Task<ActionResult> DeleteCourse(Guid id, CancellationToken cancellationToken)
    {
        await _deleteCourse.ExecuteAsync(id, cancellationToken);
        return Ok();
    }

    [HttpPost("getFullCourse")]
    public async Task<ActionResult<FullCourseResponse>> GetFullCourse(CourseInfoRequest dto, CancellationToken cancellationToken)
    {
        var response = await _getFullCourse.ExecuteAsync(dto, cancellationToken);
        return Ok(response);
    }
}
