using ToDoList.Models;

namespace ToDoList.Services;

public class TaskService(IToDoService service, ITaskFactory taskFactory)
{
    public void AddTask(TaskModel task)
    {
        var newTask = taskFactory.CreateTask(task);
        service.AddTask(newTask);
    }
}