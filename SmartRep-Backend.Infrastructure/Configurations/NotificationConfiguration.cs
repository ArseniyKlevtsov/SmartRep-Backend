using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartRep_Backend.Domain.Entities;

namespace SmartRep_Backend.Infrastructure.Configurations;
public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(n => n.Id);

        builder.Property(n => n.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(n => n.Message)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(n => n.TriggerTime)
            .IsRequired();

        builder.Property(n => n.Type)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(n => n.User)
            .WithMany(u => u.Notifications)
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(n => n.Lesson)
            .WithMany(l => l.Notifications)
            .HasForeignKey(n => n.LessonId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(n => n.UserId);
        builder.HasIndex(n => n.LessonId);
        builder.HasIndex(n => n.TriggerTime);
        builder.HasIndex(n => n.IsRead);
    }
}