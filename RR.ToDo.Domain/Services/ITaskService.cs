using RR.ToDo.Domain.Models;
using System.Collections.Immutable;

namespace RR.ToDo.Domain.Services;

public interface ITaskService
{
    Task<TaskModel> AddAsync(TaskModel task);
    Task UpdateAsync(TaskModel task);
    Task RemoveAsync(int id);
    Task<TaskModel?> GetByIdAsync(int id);
    Task<IImmutableList<TaskModel>> GetAllAsync(int? status, DateOnly dueDate);
}
