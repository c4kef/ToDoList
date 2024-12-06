using ToDoList.Services;

namespace ToDoList.ViewModels;

public class MainViewModel
{
    public ContentControlViewModel ContentControlViewModel { get; }
    public ListTasksViewModel TaskListViewModel { get; }

    public MainViewModel(IToDoService service, ITaskFactory taskFactory, TaskService taskService)
    {
        TaskListViewModel = new ListTasksViewModel(service);
        ContentControlViewModel = new ContentControlViewModel(taskService);

        TaskListViewModel.PropertyChanged += (sender, args) =>
        {
            switch (args.PropertyName)
            {
                case nameof(ListTasksViewModel.SelectedTask):
                    if (TaskListViewModel.SelectedTask is null)
                        return;

                    ContentControlViewModel.Task.Id = TaskListViewModel.SelectedTask.Id;
                    ContentControlViewModel.Task.Title = TaskListViewModel.SelectedTask.Title;
                    ContentControlViewModel.Task.Description = TaskListViewModel.SelectedTask.Description;
                    ContentControlViewModel.Task.IsCompleted = TaskListViewModel.SelectedTask.IsCompleted;
                    break;
            }
        };
    }
}