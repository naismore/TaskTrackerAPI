using Task = Domain.Models.Task;

namespace Domain.Interfaces;

public interface ITaskRepository
{
    Task<List<Task>> GetListAsync();
    void Insert(Task task);
    Task<int> SaveAsync();
}