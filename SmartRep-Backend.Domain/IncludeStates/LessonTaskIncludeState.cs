using SmartRep_Backend.Domain.interfaces;

namespace SmartRep_Backend.Domain.IncludeStates;
public class LessonTaskIncludeState : IIncludeState
{
    public bool IncludeLesson { get; set; }
}
