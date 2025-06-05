using AutoMapper;
using SmartRep_Backend.Application.Dtos.LessonTasksDtos.Responses;
using SmartRep_Backend.Domain.Entities;

namespace SmartRep_Backend.Application.Mapping;
public class LessonTaskProfile: Profile
{
    public LessonTaskProfile() 
    {
        CreateMap<LessonTask, LessonTaskResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name ?? string.Empty))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description ?? string.Empty))
            .ForMember(dest => dest.IsSolved, opt => opt.MapFrom(src => src.IsSolved))
            .ForMember(dest => dest.FileUrl, opt => opt.MapFrom(src => src.Url))
            .ForMember(dest => dest.Grade, opt => opt.MapFrom(src => src.Grade));
    }
}
