using System.Collections.ObjectModel;
using System.ComponentModel;
using ToDoList.Models;
using ToDoList.Models.Interface;
using ToDoList.Services;

namespace ToDoList.ViewModels;

public class ListTasksViewModel : INotifyPropertyChanged
{
    public ListTasksViewModel(IToDoService service, TaskCommandService taskCommandService)
    {
        Tasks = service.GetTasks();
        CancelCommand = taskCommandService.CreateCancelCommand(CancelTask);

        ObservableTaskModel = taskCommandService.TaskViewCommands.ObservableTaskModel;
        ObservableTaskModel.Set(TaskModel.CreateEmpty(), [CancelCommand]);
    }

    public ObservableCollection<ObservableTaskModel> Tasks { get; set; }
    public ObservableTaskModel ObservableTaskModel { get; }
    public CommandStruct CancelCommand { get; set; }
    
    private ObservableTaskModel? _selectedTask;

    public ObservableTaskModel? SelectedTask
    {
        get => _selectedTask;
        set
        {
            if (_selectedTask != null && _selectedTask == value)
                return;
            
            _selectedTask = value;
            OnPropertyChanged(nameof(SelectedTask));
        }
    }

    private void CancelTask() => SelectedTask = null;
    
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}