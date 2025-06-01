using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRep_Backend.Domain.Entities;

namespace SmartRep_Backend.Infrastructure.Configurations;

public class StudentProfileConfiguration : IEntityTypeConfiguration<StudentProfile>
{
    public void Configure(EntityTypeBuilder<StudentProfile> builder)
    {
        builder.HasKey(sp => sp.Id);

        builder.Property(sp => sp.AboutMe)
            .HasMaxLength(500);

        builder.HasOne(sp => sp.User)
            .WithOne(u => u.StudentProfile)
            .HasForeignKey<StudentProfile>(sp => sp.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(sp => sp.Lessons)
            .WithOne(l => l.StudentProfile)
            .HasForeignKey(l => l.StudentProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(sp => sp.Courses)
            .WithMany(c => c.Students)
            .UsingEntity(j => j.ToTable("StudentCourses"));

        builder.HasIndex(sp => sp.UserId)
            .IsUnique();
    }
}