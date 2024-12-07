using ToDoList.Models;

namespace ToDoList.Services;

public class TaskService(IToDoService service, ITaskFactory taskFactory)
{
    public void AddTask(TaskModel task)
    {
        var newTask = taskFactory.CreateTask(task);
        service.AddTask(newTask);
        service.UpdateTasks();
    }

    public void UpdateTask(TaskModel task)
    {
        service.UpdateTask(task);
        service.UpdateTasks();
    }

    public void DeleteTask(TaskModel task)
    {
        service.DeleteTask(task);
        service.UpdateTasks();
    }
}