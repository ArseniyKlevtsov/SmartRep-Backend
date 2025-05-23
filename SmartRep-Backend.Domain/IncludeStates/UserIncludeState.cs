using SmartRep_Backend.Domain.interfaces;

namespace SmartRep_Backend.Domain.IncludeStates;
public class UserIncludeState : IIncludeState
{
    public bool IncludeCoursesAsTeacher { get; set; }
    public bool IncludeCoursesAsStudent { get; set; }
    public bool IncludeLessonsAsTeacher { get; set; }
    public bool IncludeLessonsAsStudent { get; set; }
    public bool IncludeNotifications { get; set; }
    public bool IncludeComments { get; set; }
}
