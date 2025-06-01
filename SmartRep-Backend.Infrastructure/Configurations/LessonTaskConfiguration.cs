using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartRep_Backend.Domain.Entities;

namespace SmartRep_Backend.Infrastructure.Configurations;
public class LessonTaskConfiguration : IEntityTypeConfiguration<LessonTask>
{
    public void Configure(EntityTypeBuilder<LessonTask> builder)
    {
        builder.HasKey(lt => lt.Id);

        builder.Property(lt => lt.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(lt => lt.Description)
            .HasMaxLength(1000);

        builder.Property(lt => lt.Url)
            .HasMaxLength(500);

        builder.Property(lt => lt.IsSolved)
            .IsRequired();

        builder.Property(lt => lt.Grade)
            .IsRequired();

        builder.HasOne(lt => lt.Lesson)
            .WithMany(l => l.LessonTasks)
            .HasForeignKey(lt => lt.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(lt => lt.LessonId);
    }
}