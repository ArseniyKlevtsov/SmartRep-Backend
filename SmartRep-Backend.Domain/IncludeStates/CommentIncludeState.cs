using SmartRep_Backend.Domain.interfaces;

namespace SmartRep_Backend.Domain.IncludeStates;
public class CommentIncludeState : IIncludeState
{
    public bool IncludeUser { get; set; }
    public bool IncludeLesson { get; set; }
}
