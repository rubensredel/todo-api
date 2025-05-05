using RR.ToDo.Domain.Enums;

namespace RR.ToDo.Domain.Models;

public class TaskModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public StatusEnum Status { get; set; }
    public DateOnly DueDate { get; set; }
    public string StatusDescription
    {
        get
        {
            return Status switch
            {
                StatusEnum.ToDo => "To Do",
                StatusEnum.InProgress => "In Progress",
                StatusEnum.Done => "Done",
                _ => "Unknown"
            };
        }
    }
}
