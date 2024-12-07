using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models;

public class TaskModel
{
    public const int TitleMaxLength = 120;
    public const int DescriptionMaxLength = 1024;

    public required int Id { get; set; }
    [MaxLength(TitleMaxLength)] public required string Title { get; set; }
    [MaxLength(DescriptionMaxLength)] public required string Description { get; set; }
    public required bool IsCompleted { get; set; }

    public static TaskModel CreateEmpty() => new TaskModel()
    {
        Id = -1,
        Title = string.Empty,
        Description = string.Empty,
        IsCompleted = false
    };
}