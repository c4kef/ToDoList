using ToDoList.Models;

namespace ToDoList.Services;

public interface ITaskFactory
{
    ToDoTask CreateTask(string? title, string? description, bool isCompleted);
}