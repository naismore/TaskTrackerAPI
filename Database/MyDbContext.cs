using Microsoft.EntityFrameworkCore;
using TaskTracker.Backend.Models;

public class MyDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<TaskTracker.Backend.Models.Task> Tasks => Set<TaskTracker.Backend.Models.Task>();
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        Database.EnsureCreated();
        System.Console.WriteLine("Database was created!");
    }
}