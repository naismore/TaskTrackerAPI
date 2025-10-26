using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Models.Task;

namespace Infrastructure.Database;

public class TaskTrackerDbContext : DbContext
{
    public DbSet<Task> Tasks { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}