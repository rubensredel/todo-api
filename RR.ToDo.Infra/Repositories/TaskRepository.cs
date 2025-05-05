using Microsoft.EntityFrameworkCore;
using RR.ToDo.Domain.Models;
using RR.ToDo.Domain.Repositories;
using RR.ToDo.Infra.Contexts;
using System.Collections.Immutable;

namespace RR.ToDo.Infra.Repositories;

public class TaskRepository(EntityContext entity) : ITaskRepository
{
    public async Task<IImmutableList<TaskModel>> GetAllAsync(int? status, DateOnly dueDate)
    {
        var tasks = entity.Tasks.AsNoTracking();
        if (status.HasValue)
            tasks = tasks.Where(x => (int)x.Status == status);
        if (dueDate != default)
            tasks = tasks.Where(x => x.DueDate == dueDate);
        return tasks.ToImmutableList();
    }

    public async Task<TaskModel> AddAsync(TaskModel task)
    {
        await entity.Tasks.AddAsync(task);
        await entity.SaveChangesAsync();
        return task;
    }

    public async Task UpdateAsync(int id, TaskModel task)
    {
        bool exists = await entity.Tasks.AsNoTracking().AnyAsync(x => x.Id == id);
        if (!exists)
            throw new Exception("Task not found");
        task.Id = id;
        entity.Tasks.Update(task);
        await entity.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var task = await entity.Tasks.FindAsync(id) ?? throw new Exception("Task not found");
        entity.Tasks.Remove(task);
        return await entity.SaveChangesAsync() > 0;
    }

    public async Task<TaskModel?> GetByIdAsync(int id)
        => await entity.Tasks.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
}
