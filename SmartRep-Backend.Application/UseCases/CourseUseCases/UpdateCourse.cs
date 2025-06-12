using AutoMapper;
using SmartRep_Backend.Application.Dtos.Courses.Requests;
using SmartRep_Backend.Application.Interfaces.UseCases.CourseUseCases;
using SmartRep_Backend.Domain.IncludeStates;
using SmartRep_Backend.Domain.interfaces.Repositories;

namespace SmartRep_Backend.Application.UseCases.CourseUseCases;
public class UpdateCourse : IUpdateCourse
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCourse(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task ExecuteAsync(UpdateCourseRequest dto, CancellationToken cancellationToken)
    {
        var course = await _unitOfWork.Courses.GetWithStudentsAsync(dto.CourseId, cancellationToken);

        if (course == null)
        {
            throw new ArgumentException($"Course with ID {dto.CourseId} was not found");
        }

        _mapper.Map(dto, course);


        var currentStudentNames = course.Students?.Select(s => s.User.Username).ToHashSet() ?? new HashSet<string>();

        var newStudentNames = dto.studentNames.Except(currentStudentNames).ToList();
        var usernamesToRemove = currentStudentNames.Except(newStudentNames).ToList();

        if (newStudentNames.Any())
        {
            var state = new UserIncludeState()
            {
                IncludeStudentProfile = true
            };
            var studentsToAdd = (await _unitOfWork.Users
                .GetWithIncludeByPredicateAsync(u =>  newStudentNames.Contains(u.Username),state, cancellationToken))
                .ToList();

            var foundStudentNames = studentsToAdd.Select(s => s.Username).ToHashSet();
            var notFoundNames = newStudentNames.Except(foundStudentNames).ToList();

            if (notFoundNames.Any())
            {
                throw new ArgumentException($"Students not found: {string.Join(", ", notFoundNames)}");
            }

            foreach (var student in studentsToAdd)
            {
                course.Students.Add(student.StudentProfile);
            }
        }
        await _unitOfWork.Courses.UpdateAsync(course, cancellationToken);
        await _unitOfWork.SaveAsync();
    }
}