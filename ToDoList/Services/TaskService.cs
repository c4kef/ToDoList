using ToDoList.Models;

namespace ToDoList.Services;

public class TaskService(IToDoService service)
{
    public void AddTask(TaskModel task)
    {
        task.Id = Guid.NewGuid().GetHashCode();//Сюда поступают только таски которые мы создаем
        
        service.AddTask(task);
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