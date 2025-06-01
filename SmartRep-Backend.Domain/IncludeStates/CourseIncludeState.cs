using SmartRep_Backend.Domain.interfaces;

namespace SmartRep_Backend.Domain.IncludeStates;
public class CourseIncludeState : IIncludeState
{
    public bool IncludeTeacherProfile { get; set; }
    public bool IncludeStudents { get; set; }
    public bool IncludeLessons { get; set; }
}