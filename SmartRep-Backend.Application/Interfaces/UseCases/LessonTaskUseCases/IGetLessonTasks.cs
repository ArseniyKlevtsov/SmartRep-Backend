using SmartRep_Backend.Application.Dtos.LessonDtos.Requests;
using SmartRep_Backend.Application.Dtos.LessonTasksDtos.Responses;

namespace SmartRep_Backend.Application.Interfaces.UseCases.LessonTaskUseCases;
public interface IGetLessonTasks
{
    Task<LessonTasksResponse> ExecuteAsync(GetLessonRequest dto, CancellationToken cancellationToken);
}
