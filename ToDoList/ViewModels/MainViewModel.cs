using ToDoList.Services;

namespace ToDoList.ViewModels;

public class MainViewModel
{
    public ContentControlViewModel ContentControlViewModel { get; }
    public ListTasksViewModel TaskListViewModel { get; }

    public MainViewModel(IToDoService service, ITaskFactory taskFactory, TaskService taskService, TaskCommandService taskCommandService)
    {
        TaskListViewModel = new ListTasksViewModel(service);
        ContentControlViewModel = new ContentControlViewModel(taskCommandService);

        TaskListViewModel.PropertyChanged += (sender, args) =>
        {
            switch (args.PropertyName)
            {
                case nameof(ListTasksViewModel.SelectedTask):
                    if (TaskListViewModel.SelectedTask is null)
                        return;

                    ContentControlViewModel.Task.ObservableTaskModel.Set(TaskListViewModel.SelectedTask.Get());
                    break;
            }
        };
    }
}