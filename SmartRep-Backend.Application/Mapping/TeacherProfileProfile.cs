using AutoMapper;
using SmartRep_Backend.Application.Dtos.AuthDtos.Responses;
using SmartRep_Backend.Application.Dtos.TeacherDtos.Responses;
using SmartRep_Backend.Application.Dtos.UserDtos.Responses;
using SmartRep_Backend.Domain.Entities;

namespace SmartRep_Backend.Application.Mapping;
public class TeacherProfileProfile : Profile
{
    public TeacherProfileProfile()
    {
        CreateMap<TeacherProfile, TeacherPreviewResponse>()
            .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.TeacherAvatarUrl, opt => opt.MapFrom(src => src.User.AvatarUrl ?? string.Empty))
            .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.User.FullName ?? string.Empty))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email ?? string.Empty))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.User.Phone ?? string.Empty))
            .ForMember(dest => dest.TeacherDescription, opt => opt.MapFrom(src => src.AboutMe));
    }
}
