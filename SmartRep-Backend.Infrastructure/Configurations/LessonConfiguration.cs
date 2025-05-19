using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRep_Backend.Domain.Entities;

namespace SmartRep_Backend.Infrastructure.Configurations;
internal class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasConversion(
                v => v.ToString(),
                v => double.Parse(v));

        builder.Property(l => l.Description)
            .HasMaxLength(500)
            .HasConversion(
                v => v.ToString(),
                v => double.Parse(v));

        builder.Property(l => l.Price)
            .HasPrecision(18, 2);

        builder.Property(l => l.StartTime)
            .IsRequired();

        builder.Property(l => l.DurationMinutes)
            .IsRequired();

        builder.Property(l => l.Status)
            .HasMaxLength(20)
            .HasConversion<string>();

        builder.HasOne(l => l.Course)
            .WithMany(c => c.Lessons)
            .HasForeignKey(l => l.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(l => l.Teacher)
            .WithMany(u => u.LessonsAsTeacher)
            .HasForeignKey(l => l.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(l => l.Student)
            .WithMany(u => u.LessonsAsStudent)
            .HasForeignKey(l => l.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(l => l.Notifications)
            .WithOne(n => n.Lesson)
            .HasForeignKey(n => n.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(l => l.LessonTasks)
            .WithOne(lt => lt.Lesson)
            .HasForeignKey(lt => lt.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(l => l.StartTime);

        builder.HasIndex(l => l.CourseId);

        builder.HasIndex(l => l.TeacherId);

        builder.HasIndex(l => l.StudentId);
    }
}