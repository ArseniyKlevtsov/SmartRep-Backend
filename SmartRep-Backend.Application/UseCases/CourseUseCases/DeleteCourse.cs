using SmartRep_Backend.Application.Interfaces.UseCases.CourseUseCases;
using SmartRep_Backend.Domain.interfaces.Repositories;

namespace SmartRep_Backend.Application.UseCases.CourseUseCases;
public class DeleteCourse : IDeleteCourse
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCourse(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task ExecuteAsync(Guid courseId, CancellationToken cancellationToken)
    {
        var course = await _unitOfWork.Courses.GetByIdAsync(courseId, cancellationToken);

        if (course == null)
        {
            throw new ArgumentException($"Course with ID {courseId} was not found");
        }

        // Удаляем курс
        await _unitOfWork.Courses.DeleteAsync(course, cancellationToken);
        await _unitOfWork.SaveAsync();
    }
}
