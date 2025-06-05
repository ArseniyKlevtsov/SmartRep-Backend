using SmartRep_Backend.Application.Dtos.CommentDtos;
using SmartRep_Backend.Application.Dtos.Courses.Requests;
using SmartRep_Backend.Application.Dtos.Courses.Responses;
using SmartRep_Backend.Application.Dtos.LessonDtos.Requests;

namespace SmartRep_Backend.Application.Interfaces.UseCases.CommentUseCases;
public interface IGetLessonComents
{
    Task<CommentsResponse> ExecuteAsync(GetLessonRequest dto, CancellationToken cancellationToken);
}
