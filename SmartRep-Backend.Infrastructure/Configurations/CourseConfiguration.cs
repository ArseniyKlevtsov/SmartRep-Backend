using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartRep_Backend.Domain.Entities;

namespace SmartRep_Backend.Infrastructure.Configurations;
public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.AvatarUrl)
            .HasMaxLength(255);

        builder.Property(c => c.Description)
            .HasMaxLength(1000);

        builder.HasOne(c => c.Teacher)
            .WithMany(u => u.CoursesAsTeacher)
            .HasForeignKey(c => c.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.Students)
            .WithMany(u => u.CoursesAsStudent);

        builder.HasMany(c => c.Lessons)
            .WithOne(l => l.Course)
            .HasForeignKey(l => l.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(c => c.TeacherId);
    }
}
