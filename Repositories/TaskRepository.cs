using Microsoft.EntityFrameworkCore;
namespace TaskTracker.Backend.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly MyDbContext _context;

    public TaskRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<List<Models.Task>> GetTaskListAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<(bool success, Models.Task? task)> CreateTaskAsync(Models.Task task)
    {
        await _context.Tasks.AddAsync(task);
        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows > 0 ? (true, task) : (false, null);
    }
}