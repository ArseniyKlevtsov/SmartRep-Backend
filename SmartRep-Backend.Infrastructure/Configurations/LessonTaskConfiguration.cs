using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartRep_Backend.Domain.Entities;

namespace SmartRep_Backend.Infrastructure.Configurations;
public class LessonTaskConfiguration : IEntityTypeConfiguration<LessonTask>
{
    public void Configure(EntityTypeBuilder<LessonTask> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(t => t.Description)
            .HasMaxLength(1000);

        builder.Property(t => t.Urls)
            .HasMaxLength(500);

        builder.HasOne(t => t.Lesson)
            .WithMany(l => l.LessonTasks)
            .HasForeignKey(t => t.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(t => t.LessonId);
    }
}
