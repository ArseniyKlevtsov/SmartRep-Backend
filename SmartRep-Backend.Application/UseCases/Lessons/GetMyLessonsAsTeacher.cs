using AutoMapper;
using SmartRep_Backend.Application.Dtos.LessonDtos.Requests;
using SmartRep_Backend.Application.Dtos.LessonDtos.Responses;
using SmartRep_Backend.Application.Interfaces.UseCases.Lessons;
using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.interfaces.Repositories;

namespace SmartRep_Backend.Application.UseCases.Lessons;
public class GetMyLessonsAsTeacher : IGetMyLessonsAsTeacher
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetMyLessonsAsTeacher(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetMyLessonsResponse> ExecuteAsync(GetMyLessonsRequest dto, CancellationToken cancellationToken)
    {
        IEnumerable<Lesson> lessons = new List<Lesson>();
        if (dto.AsTeacher)
        {
            lessons = await _unitOfWork.Lessons.GetTeacherLessonsByTimeAsync(dto.UsedId, dto.StartDate, dto.EndDate, cancellationToken);

        }
        else
        {
            lessons = await _unitOfWork.Lessons.GetStudentLessonsByTimeAsync(dto.UsedId, dto.StartDate, dto.EndDate, cancellationToken);

        }

        var response = new GetMyLessonsResponse
        {
            lessons = _mapper.Map<List<LessonPreviwResponse>>(lessons)
        };
        return response;
    }

}
