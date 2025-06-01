using SmartRep_Backend.Domain.interfaces;

namespace SmartRep_Backend.Domain.IncludeStates;
public class UserIncludeState : IIncludeState
{
    public bool IncludeTeacherProfile { get; set; }
    public bool IncludeStudentProfile { get; set; }
    public bool IncludeNotifications { get; set; }
    public bool IncludeComments { get; set; }
}
