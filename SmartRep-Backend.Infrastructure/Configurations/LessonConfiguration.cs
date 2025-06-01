using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRep_Backend.Domain.Entities;

namespace SmartRep_Backend.Infrastructure.Configurations;
public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(l => l.Description)
            .HasMaxLength(1000);

        builder.Property(l => l.Price)
            .IsRequired();

        builder.Property(l => l.StartTime)
            .IsRequired();

        builder.Property(l => l.DurationMinutes)
            .IsRequired();

        builder.Property(l => l.Status)
            .HasMaxLength(50);

        builder.HasOne(l => l.Course)
            .WithMany(c => c.Lessons)
            .HasForeignKey(l => l.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(l => l.StudentProfile)
            .WithMany(sp => sp.Lessons)
            .HasForeignKey(l => l.StudentProfileId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(l => l.Notifications)
            .WithOne(n => n.Lesson)
            .HasForeignKey(n => n.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(l => l.LessonTasks)
            .WithOne(lt => lt.Lesson)
            .HasForeignKey(lt => lt.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(l => l.Comments)
            .WithOne(c => c.Lesson)
            .HasForeignKey(c => c.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(l => l.CourseId);
        builder.HasIndex(l => l.StudentProfileId);
    }
}