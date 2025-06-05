using AutoMapper;
using SmartRep_Backend.Application.Dtos.Courses.Responses;
using SmartRep_Backend.Application.Dtos.LessonDtos.Requests;
using SmartRep_Backend.Application.Dtos.LessonTasksDtos.Responses;
using SmartRep_Backend.Application.Interfaces.UseCases.LessonTaskUseCases;
using SmartRep_Backend.Domain.interfaces.Repositories;

namespace SmartRep_Backend.Application.UseCases.LessonTasks;
public class GetLessonTasks : IGetLessonTasks
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetLessonTasks(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<LessonTasksResponse> ExecuteAsync(GetLessonRequest dto, CancellationToken cancellationToken)
    {
        var allLessonTasks = await _unitOfWork.LessonTasks.GetByLessonIdAsync(dto.LessonId ,cancellationToken);

        var response = new LessonTasksResponse
        {
            LessonTask = _mapper.Map<List<LessonTaskResponse>>(allLessonTasks)
        };

        return response;
    }
}
