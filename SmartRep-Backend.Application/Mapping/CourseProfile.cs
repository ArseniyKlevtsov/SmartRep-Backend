using AutoMapper;
using SmartRep_Backend.Application.Dtos.Courses.Requests;
using SmartRep_Backend.Application.Dtos.Courses.Responses;
using SmartRep_Backend.Application.Dtos.UserDtos.Responses;
using SmartRep_Backend.Domain.Entities;

namespace SmartRep_Backend.Application.Mapping;
public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<Course, CoursePreviewResponse>()
            .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CourseAvatarUrl, opt => opt.MapFrom(src => src.AvatarUrl ?? string.Empty))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Name ?? string.Empty))
            .ForMember(dest => dest.CourseDescription, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.TeacherAvatarUrl, opt => opt.MapFrom(src => src.TeacherProfile.User.AvatarUrl ?? string.Empty))
            .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.TeacherProfile.User.FullName ?? string.Empty));


        CreateMap<CreateCourseRequest, Course>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name ?? string.Empty))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description ?? string.Empty));

        CreateMap<UpdateCourseRequest, Course>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name ?? string.Empty))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description ?? string.Empty));

        CreateMap<Course, FullCourseResponse>()
            .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.CourseDescription, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.CourseAvatarUrl, opt => opt.MapFrom(src => src.AvatarUrl))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src =>
                src.TeacherProfile != null && src.TeacherProfile.User != null
                    ? src.TeacherProfile.User.Username
                    : null))
            .ForMember(dest => dest.TeacherAvatarUrl, opt => opt.MapFrom(src =>
                src.TeacherProfile != null && src.TeacherProfile.User != null
                    ? src.TeacherProfile.User.AvatarUrl
                    : null))
            .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src =>
                src.TeacherProfile != null && src.TeacherProfile.User != null
                    ? src.TeacherProfile.User.Id : Guid.NewGuid()))
            .ForMember(dest => dest.Students, opt => opt.MapFrom(src =>
                src.Students != null
                    ? src.Students.Select(s => new ShortcutUserProfileResponse
                    {
                        Username = s.User.FullName ?? string.Empty,
                        AvatarUrl = s.User.AvatarUrl ?? string.Empty
                    }).ToList()
                    : new List<ShortcutUserProfileResponse>()));
    }
}
