using SmartRep_Backend.Application.Dtos.UserDtos.Responses;

namespace SmartRep_Backend.Application.Dtos.Courses.Responses;
public class FullCourseResponse
{
    public Guid CourseId { get; set; }
    public string CourseName { get; set; }
    public string CourseDescription { get; set; }
    public string CourseAvatarUrl { get; set; }
    public double Price { get; set; }
    public string TeacherName { get; set; }
    public string TeacherAvatarUrl { get; set; }

    public List<ShortcutUserProfileResponse> Students {  get; set; }
}
