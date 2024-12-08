using ToDoList.Services;

namespace ToDoList.ViewModels;

public class MainViewModel
{
    public ContentControlViewModel ContentControlViewModel { get; }
    public ListTasksViewModel TaskListViewModel { get; }

    public MainViewModel(IToDoService service, TaskCommandService taskCommandService)
    {
        TaskListViewModel = new ListTasksViewModel(service, taskCommandService);
        ContentControlViewModel = new ContentControlViewModel(taskCommandService);
        
        TaskListViewModel.PropertyChanged += (_, args) =>
        {
            switch (args.PropertyName)
            {
                case nameof(ListTasksViewModel.SelectedTask):
                    if (TaskListViewModel.SelectedTask is null)
                        return;

                    ContentControlViewModel.ObservableTaskModel.Set(TaskListViewModel.SelectedTask.Get());
                    break;
            }
        };
    }
}