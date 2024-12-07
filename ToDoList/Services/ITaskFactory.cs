using ToDoList.Models;

namespace ToDoList.Services;

public interface ITaskFactory
{
    TaskModel CreateTask(TaskModel task);
}