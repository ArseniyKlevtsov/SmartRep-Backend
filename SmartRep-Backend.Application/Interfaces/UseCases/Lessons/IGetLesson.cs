using SmartRep_Backend.Application.Dtos.LessonDtos.Requests;
using SmartRep_Backend.Application.Dtos.LessonDtos.Responses;

namespace SmartRep_Backend.Application.Interfaces.UseCases.Lessons;
public interface IGetLesson
{
    Task<GetLessonResponse> ExecuteAsync(GetLessonRequest dto, CancellationToken cancellationToken);
}
