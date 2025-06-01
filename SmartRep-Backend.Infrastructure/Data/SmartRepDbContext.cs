using Microsoft.EntityFrameworkCore;
using SmartRep_Backend.Domain.Entities;

namespace SmartRep_Backend.Infrastructure.Data;
public class SmartRepDbContext : DbContext
{
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<LessonTask> LessonTasks { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<TeacherProfile> TeacherProfiles { get; set; }
    public DbSet<StudentProfile> StudentProfiles { get; set; }

    public SmartRepDbContext(DbContextOptions<SmartRepDbContext> options) : base(options) { Database.EnsureCreated(); }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SmartRepDbContext).Assembly);
    }
}
