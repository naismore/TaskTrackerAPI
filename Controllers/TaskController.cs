using Microsoft.AspNetCore.Mvc;
using TaskTracker.Backend.Models;

namespace TaskTracker.Backend.Controllers;

public class TaskController : ControllerBase
{
    private readonly ILogger<TaskController> _logger;
    private readonly ITaskRepository _taskRepository;

    public TaskController(ILogger<TaskController> logger, ITaskRepository taskRepository)
    {
        _logger = logger;
        _taskRepository = taskRepository;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetTaskList()
    {
        return Ok(await _taskRepository.GetTaskListAsync());
    }

    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(Models.Task), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateTask([FromBody] Models.Task task)
    {
        (bool success, Models.Task? newTask) = await _taskRepository.CreateTaskAsync(task);
        return success ? Created($"api/user/{newTask?.Id}", newTask) : BadRequest();
    }
}