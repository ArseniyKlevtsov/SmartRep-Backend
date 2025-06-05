using AutoMapper;
using SmartRep_Backend.Application.Dtos.LessonDtos.Requests;
using SmartRep_Backend.Application.Dtos.LessonDtos.Responses;
using SmartRep_Backend.Application.Interfaces.UseCases.Lessons;
using SmartRep_Backend.Domain.interfaces.Repositories;

namespace SmartRep_Backend.Application.UseCases.Lessons;
public class GetLesson : IGetLesson
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetLesson(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetLessonResponse> ExecuteAsync(GetLessonRequest dto, CancellationToken cancellationToken)
    {
        var lesson = await _unitOfWork.Lessons.GetByPredicateAsync(l => l.Id == dto.LessonId, cancellationToken);

        return _mapper.Map<GetLessonResponse>(lesson);
        ;
    }
}
