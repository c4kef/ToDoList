namespace ToDoList.Services;

public class TaskService(IToDoService service, ITaskFactory taskFactory)
{
    public void AddTask(string title, string description, bool isCompleted)
    {
        var newTask = taskFactory.CreateTask(title, description, isCompleted);
        service.AddTask(newTask);
    }
}