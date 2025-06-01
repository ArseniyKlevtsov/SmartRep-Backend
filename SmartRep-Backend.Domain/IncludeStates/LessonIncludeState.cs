using SmartRep_Backend.Domain.interfaces;

namespace SmartRep_Backend.Domain.IncludeStates;
public class LessonIncludeState : IIncludeState
{
    public bool IncludeCourse { get; set; }
    public bool IncludeStudentProfile { get; set; }
    public bool IncludeNotifications { get; set; }
    public bool IncludeLessonTasks { get; set; }
    public bool IncludeComments { get; set; }
}
