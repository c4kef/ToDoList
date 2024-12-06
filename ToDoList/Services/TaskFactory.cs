using ToDoList.Models;

namespace ToDoList.Services;

public class TaskFactory : ITaskFactory
{
    public ToDoTask CreateTask(string? title, string? description, bool isCompleted)
    {
        if (string.IsNullOrEmpty(title)) 
            throw new ArgumentException("Заголовок не может быть пустым", nameof(title));
        if (string.IsNullOrEmpty(description))
            throw new ArgumentException("Описание не может быть пустым", nameof(description));

        return new ToDoTask
        {
            Id = Guid.NewGuid().GetHashCode(),
            Title = title,
            Description = description,
            IsCompleted = isCompleted
        };
    }
}