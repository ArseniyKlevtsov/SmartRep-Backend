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
            .HasMaxLength(100);

        builder.Property(c => c.AvatarUrl)
            .HasMaxLength(500);

        builder.Property(c => c.Description)
            .HasMaxLength(1000);

        builder.Property(c => c.Price)
            .IsRequired();

        builder.HasOne(c => c.TeacherProfile)
            .WithMany(tp => tp.Courses)
            .HasForeignKey(c => c.TeacherProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Students)
            .WithMany(sp => sp.Courses)
            .UsingEntity(j => j.ToTable("StudentCourses"));

        builder.HasMany(c => c.Lessons)
            .WithOne(l => l.Course)
            .HasForeignKey(l => l.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(c => c.TeacherProfileId);
    }
}