using SmartRep_Backend.Domain.interfaces;

namespace SmartRep_Backend.Domain.IncludeStates;
public class StudentProfileIncludeState : IIncludeState
{
    public bool IncludeUser { get; set; }
    public bool IncludeLessons { get; set; }
    public bool IncludeCourses { get; set; }
}
