public interface ITaskRepository
{
    Task<List<TaskTracker.Backend.Models.Task>> GetTaskListAsync();
    Task<(bool success, TaskTracker.Backend.Models.Task? task)> CreateTaskAsync(TaskTracker.Backend.Models.Task task);
}