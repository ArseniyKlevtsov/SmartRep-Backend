using AutoMapper;
using SmartRep_Backend.Application.Dtos.Courses.Responses;
using SmartRep_Backend.Domain.Entities;

namespace SmartRep_Backend.Application.Mapping;
public class CoursProfile : Profile
{
    public CoursProfile()
    {
        CreateMap<Course, CoursePreviewResponse>()
            .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CourseAvatarUrl, opt => opt.MapFrom(src => src.AvatarUrl ?? string.Empty))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Name ?? string.Empty))
            .ForMember(dest => dest.CourseDescription, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.TeacherAvatarUrl, opt => opt.MapFrom(src => src.TeacherProfile.User.AvatarUrl ?? string.Empty))
            .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.TeacherProfile.User.FullName ?? string.Empty));
    }
}
