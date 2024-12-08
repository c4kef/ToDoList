using ToDoList.Services;
using ToDoList.ViewModels.ListTasks.FilterAndSort;

namespace ToDoList.ViewModels;

public class MainViewModel
{
    public ContentControlViewModel ContentControlViewModel { get; }
    public ListTasksViewModel TaskListViewModel { get; }

    public MainViewModel(IToDoService service, ITaskFilter filter, TaskCommandService taskCommandService)
    {
        TaskListViewModel = new ListTasksViewModel(service, filter, taskCommandService);
        ContentControlViewModel = new ContentControlViewModel(taskCommandService);
        
        TaskListViewModel.TaskSortFinder.PropertyChanged += (_, args) =>
        {
            switch (args.PropertyName)
            {
                case nameof(ListTasksViewModel.TaskSortFinder.SelectedTask):
                    if (TaskListViewModel.TaskSortFinder.SelectedTask is null)
                        return;

                    ContentControlViewModel.ObservableTaskModel.Set(TaskListViewModel.TaskSortFinder.SelectedTask.Get());
                    break;
            }
        };
    }
}