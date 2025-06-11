using SmartRep_Backend.Domain.interfaces;

namespace SmartRep_Backend.Domain.IncludeStates;
public class CourseIncludeState : IIncludeState
{
    public bool IncludeTeacherProfile { get; set; }
    public bool IncludeTeacherUser { get; set; }

    public bool IncludeStudents { get; set; }
    public bool IncludeStudentUsers { get; set; }

    public bool IncludeLessons { get; set; }
}