using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRep_Backend.Domain.Entities;

namespace SmartRep_Backend.Infrastructure.Configurations;
public class TeacherProfileConfiguration : IEntityTypeConfiguration<TeacherProfile>
{
    public void Configure(EntityTypeBuilder<TeacherProfile> builder)
    {
        builder.HasKey(tp => tp.Id);

        builder.Property(tp => tp.AboutMe)
            .HasMaxLength(500); 

        builder.HasOne(tp => tp.User)
            .WithOne(u => u.TeacherProfile)
            .HasForeignKey<TeacherProfile>(tp => tp.UserId)
            .OnDelete(DeleteBehavior.Cascade); 

        builder.HasMany(tp => tp.Courses)
            .WithOne(c => c.TeacherProfile)
            .HasForeignKey(c => c.TeacherProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(tp => tp.UserId)
            .IsUnique(); 
    }
}