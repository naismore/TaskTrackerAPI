using Domain.Interfaces;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Models.Task;

namespace Infrastructure.Repositories;

public class TaskRepository(TaskTrackerDbContext context) : ITaskRepository
{
    public async Task<List<Task>> GetListAsync() =>
        await context.Tasks.ToListAsync();

    public void Insert(Task task) =>
        context.Tasks.Add(task);
    
    public async Task<int> SaveAsync() =>
        await context.SaveChangesAsync();
    
}