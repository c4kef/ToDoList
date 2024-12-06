using ToDoList.Services;

namespace ToDoList.ViewModels;

public class MainViewModel(IToDoService service, ITaskFactory taskFactory, TaskService taskService)
{
    public ContentControlViewModel ContentControlViewModel { get; } = new(taskService);
    public ListTasksViewModel TaskListViewModel { get; } = new(service, taskFactory);
}