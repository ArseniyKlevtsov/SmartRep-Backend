using Microsoft.AspNetCore.Mvc;
using SmartRep_Backend.Application.Dtos.CommentDtos;
using SmartRep_Backend.Application.Dtos.LessonDtos.Requests;
using SmartRep_Backend.Application.Interfaces.UseCases.CommentUseCases;

namespace SmartRep_Backend.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly IGetLessonComents getLessonComents;

    public CommentsController(IGetLessonComents getLessonComents)
    {
        this.getLessonComents = getLessonComents;
    }

    [HttpPost("getLessonComents")]
    public async Task<ActionResult<CommentsResponse>> GetLessonComents(GetLessonRequest dto, CancellationToken cancellationToken)
    {
        var response = await getLessonComents.ExecuteAsync(dto, cancellationToken);
        return Ok(response);
    }
}
