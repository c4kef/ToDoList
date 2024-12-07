using ToDoList.Models;

namespace ToDoList.Services;

public class TaskFactory : ITaskFactory
{
    public TaskModel CreateTask(TaskModel task)
    {
        if (task.Id == -1)
            task.Id = Guid.NewGuid().GetHashCode();

        return task;
    }
}