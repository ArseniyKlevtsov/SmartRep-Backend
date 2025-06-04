using SmartRep_Backend.Application.Dtos.LessonDtos.Requests;
using SmartRep_Backend.Application.Dtos.LessonDtos.Responses;

namespace SmartRep_Backend.Application.Interfaces.UseCases.Lessons;
public interface IGetMyLessonsAsTeacher
{
    Task<GetMyLessonsResponse> ExecuteAsync(GetMyLessonsRequest dto, CancellationToken cancellationToken);
}
