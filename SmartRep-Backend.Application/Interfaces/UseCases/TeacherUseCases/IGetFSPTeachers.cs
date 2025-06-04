using SmartRep_Backend.Application.Dtos.TeacherDtos.Requests;
using SmartRep_Backend.Application.Dtos.TeacherDtos.Responses;

namespace SmartRep_Backend.Application.Interfaces.UseCases.TeacherUseCases;
public interface IGetFSPTeachers
{
    Task<GetFSPTeachersResponse> ExecuteAsync(GetFSPTeachersRequest dto, CancellationToken cancellationToken);
}
