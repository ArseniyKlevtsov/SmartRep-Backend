using SmartRep_Backend.Domain.interfaces;

namespace SmartRep_Backend.Domain.IncludeStates;
public class TeacherProfileIncludeState : IIncludeState
{
    public bool IncludeUser { get; set; }
    public bool IncludeCourses { get; set; }
}
