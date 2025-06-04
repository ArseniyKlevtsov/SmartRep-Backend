using AutoMapper;
using SmartRep_Backend.Application.Dtos.Courses.Responses;
using SmartRep_Backend.Application.Dtos.TeacherDtos.Requests;
using SmartRep_Backend.Application.Dtos.TeacherDtos.Responses;
using SmartRep_Backend.Application.Interfaces.UseCases.TeacherUseCases;
using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;
using SmartRep_Backend.Domain.interfaces.Repositories;

namespace SmartRep_Backend.Application.UseCases.TeacherUseCases;
public class GetFSPTeachers : IGetFSPTeachers
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetFSPTeachers(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetFSPTeachersResponse> ExecuteAsync(GetFSPTeachersRequest dto, CancellationToken cancellationToken)
    {
        var includeState = new TeacherProfileIncludeState()
        {
            IncludeCourses = true,
            IncludeUser = true,
        };

        var teacherProfiles = await _unitOfWork.TeacherProfiles.GetWithIncludeAsync(includeState, cancellationToken);

        var teachers = teacherProfiles.Where(tp => tp.Courses.Count> 0).ToList();

        if (!string.IsNullOrEmpty(dto.TextFilter))
        {
            teachers = teachers
                .Where(tp =>
                    tp.User != null &&
                    (tp.User.Username.Contains(dto.TextFilter, StringComparison.OrdinalIgnoreCase) ||
                    tp.AboutMe != null && tp.AboutMe.Contains(dto.TextFilter, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        var totalCount = teachers.Count();
        var pagedTeachers = teachers.Skip(dto.StartIndex).Take(dto.PageSize ?? totalCount).ToList();

        var response = new GetFSPTeachersResponse
        {
            TotalCount = totalCount,
            Teachers = _mapper.Map<List<TeacherPreviewResponse>>(pagedTeachers)
        };

        return response;
    }
}
