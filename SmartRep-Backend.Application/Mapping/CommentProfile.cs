using AutoMapper;
using SmartRep_Backend.Application.Dtos.CommentDtos;
using SmartRep_Backend.Application.Dtos.Courses.Responses;
using SmartRep_Backend.Domain.Entities;

namespace SmartRep_Backend.Application.Mapping;
public class CommentProfile: Profile
{
    public CommentProfile()
    {
        CreateMap<Comment, CommentResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message ?? string.Empty))
            .ForMember(dest => dest.FileUrl, opt => opt.MapFrom(src => src.Url))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Username ?? string.Empty))
            .ForMember(dest => dest.UserAvatarUrl, opt => opt.MapFrom(src => src.User.AvatarUrl));
    }
}
