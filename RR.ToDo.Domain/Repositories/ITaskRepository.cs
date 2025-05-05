using RR.ToDo.Domain.Models;
using System.Collections.Immutable;

namespace RR.ToDo.Domain.Repositories;

public interface ITaskRepository
{
    Task<IImmutableList<TaskModel>> GetAllAsync(int? status, DateOnly dueDate);
    Task<TaskModel> AddAsync(TaskModel task);
    Task UpdateAsync(int id, TaskModel task);
    Task<bool> DeleteAsync(int id);
    Task<TaskModel?> GetByIdAsync(int id);
}
