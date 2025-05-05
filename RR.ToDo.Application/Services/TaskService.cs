using RR.ToDo.Domain.Models;
using RR.ToDo.Domain.Repositories;
using RR.ToDo.Domain.Services;
using System.Collections.Immutable;

namespace RR.ToDo.Application.Services;

public class TaskService(ITaskRepository repository) : ITaskService
{
    public async Task<TaskModel> AddAsync(TaskModel task)
    {
        return await repository.AddAsync(task);
    }

    public async Task UpdateAsync(TaskModel task)
    {
        await repository.UpdateAsync(task.Id, task);
    }

    public async Task RemoveAsync(int id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<TaskModel?> GetByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<IImmutableList<TaskModel>> GetAllAsync(int? status, DateOnly dueDate)
    {
        return await repository.GetAllAsync(status, dueDate);
    }
}
