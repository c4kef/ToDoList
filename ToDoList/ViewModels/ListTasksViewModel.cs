using System.Collections.ObjectModel;
using System.ComponentModel;
using ToDoList.Models;
using ToDoList.Models.Interface;
using ToDoList.Services;
using ToDoList.ViewModels.ListTasks;
using ToDoList.ViewModels.ListTasks.FilterAndSort;

namespace ToDoList.ViewModels;

public class ListTasksViewModel
{
    public ListTasksViewModel(IToDoService service, ITaskFilter taskFilter, TaskCommandService taskCommandService)
    {
        TaskSortFinder = new TaskSortFinder(service);

        CancelCommand = taskCommandService.CreateCancelCommand(TaskSortFinder.CancelTask);

        ObservableTaskModel = taskCommandService.TaskViewCommands.ObservableTaskModel;
        ObservableTaskModel.Set(TaskModel.CreateEmpty(), [CancelCommand]);
        
        var handler = new SortAndFindHandler(service, taskFilter);
        TaskSortFinder.PropertyChanged += (_, args) => handler.HandlePropertyChanged(TaskSortFinder, args.PropertyName);
        
        service.GetTasks();
        TaskSortFinder.SelectedTypeSort = TaskSortFinder.SelectedSorts[0];
    }

    public TaskSortFinder TaskSortFinder { get; }
    public ObservableTaskModel ObservableTaskModel { get; }
    public CommandStruct CancelCommand { get; set; }
}