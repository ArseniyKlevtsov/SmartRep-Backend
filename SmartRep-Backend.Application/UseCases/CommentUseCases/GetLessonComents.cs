using AutoMapper;
using SmartRep_Backend.Application.Dtos.CommentDtos;
using SmartRep_Backend.Application.Dtos.LessonDtos.Requests;
using SmartRep_Backend.Application.Interfaces.UseCases.CommentUseCases;
using SmartRep_Backend.Domain.IncludeStates;
using SmartRep_Backend.Domain.interfaces.Repositories;

namespace SmartRep_Backend.Application.UseCases.CommentUseCases;
public class GetLessonComents : IGetLessonComents
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetLessonComents(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommentsResponse> ExecuteAsync(GetLessonRequest dto, CancellationToken cancellationToken)
    {
        var includeStates = new CommentIncludeState() { IncludeUser = true };
        var comments = await _unitOfWork.Comments.GetWithIncludeByPredicateAsync(c=> c.LessonId ==  dto.LessonId, includeStates, cancellationToken);

        var response = new CommentsResponse
        {
            Comments = _mapper.Map<List<CommentResponse>>(comments)
        };

        return response;
    }
}
