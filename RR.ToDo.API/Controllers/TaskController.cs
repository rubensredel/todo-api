using Microsoft.AspNetCore.Mvc;
using RR.ToDo.Domain.Models;
using RR.ToDo.Domain.Services;
using System.Collections.Immutable;

namespace RR.ToDo.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController(ITaskService service) : ControllerBase
{
    /// <summary>
    /// Get all tasks.
    /// </summary>
    /// <returns>All tasks saved.</returns>
    [HttpGet]
    public async Task<ActionResult<IImmutableList<TaskModel>>> GetAllAsync([FromQuery] int? status, [FromQuery] DateOnly dueDate)
    {
        return Ok(await service.GetAllAsync(status, dueDate));
    }

    /// <summary>
    /// Get a task by id.
    /// </summary>
    /// <param name="id">Id of task.</param>
    /// <returns>Task data.</returns>
    [HttpGet("id/{id}")]
    public async Task<ActionResult<IImmutableList<TaskModel>>> GetByIdAsync(int id)
    {
        return Ok(await service.GetByIdAsync(id));
    }

    /// <summary>
    /// Create a task.
    /// </summary>
    /// <param name="task">Task to be create.</param>
    /// <returns>Task created.</returns>
    [HttpPost]
    public async Task<ActionResult<TaskModel>> PostAsync([FromBody] TaskModel task)
    {
        var create = await service.AddAsync(task);
        return Ok(create);
    }

    /// <summary>
    /// Update a task.
    /// </summary>
    /// <param name="id">Id of task.</param>
    /// <param name="task">Task to be updated.</param>
    /// <returns>Task updated.</returns>
    [HttpPut("id/{id}")]
    public async Task<ActionResult<TaskModel>> PutAsync(int id, [FromBody] TaskModel task)
    {
        task.Id = id;
        await service.UpdateAsync(task);
        return Ok(task);
    }

    /// <summary>
    /// Delete a task.
    /// </summary>
    /// <param name="id">Id of task.</param>
    /// <returns>Task deleted.</returns>
    [HttpDelete("id/{id}")]
    public async Task<ActionResult<TaskModel>> DeleteAsync(int id)
    {
        await service.RemoveAsync(id);
        return Ok();
    }
}
