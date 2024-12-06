using System.Collections.ObjectModel;
using System.ComponentModel;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.ViewModels;

public class ListTasksViewModel(IToDoService service, ITaskFactory taskFactory) : INotifyPropertyChanged
{
    public ObservableCollection<ToDoTask> Tasks { get; set; } = service.GetTasks();//Передаем линк из сервиса

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}