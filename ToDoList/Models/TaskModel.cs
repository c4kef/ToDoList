using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models;

[Table("ToDoTasks")]
public class TaskModel
{
    public const int TitleMaxLength = 120;
    public const int DescriptionMaxLength = 1024;

    public required int Id { get; set; }
    [MaxLength(TitleMaxLength)] public required string Title { get; set; }
    [MaxLength(DescriptionMaxLength)] public required string Description { get; set; }
    public required DateTime Date { get; set; }
    public required bool IsCompleted { get; set; }

    public TaskModel ReCreate()
    {
        var model = CreateEmpty();
        model.Id = Id;
        model.Title = Title;
        model.Description = Description;
        model.Date = Date;
        model.IsCompleted = IsCompleted;
        return model;
    }
    
    public static TaskModel CreateEmpty() => new()
    {
        Id = -1,
        Title = string.Empty,
        Description = string.Empty,
        Date = DateTime.Now,
        IsCompleted = false
    };
}