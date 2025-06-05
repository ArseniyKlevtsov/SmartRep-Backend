namespace SmartRep_Backend.Application.Dtos.LessonTasksDtos.Responses;
public class LessonTaskResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string FileUrl { get; set; }
    public bool IsSolved { get; set; }
    public int Grade { get; set; }
}
