using ToDoList.Services;
using ToDoList.ViewModels.ContentControl;

namespace ToDoList.ViewModels;

public class ContentControlViewModel(TaskCommandService taskCommandService)
{
    public TaskViewModel Task { get; } = new(taskCommandService);
}