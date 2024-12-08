using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ToDoList.Models;
using ToDoList.Services;
using ToDoList.ViewModels.ListTasks.FilterAndSort;

namespace ToDoList.ViewModels.ListTasks;

public class TaskSortFinder(IToDoService service) : ObservableObject
{
    public SelectedSort[] SelectedSorts { get; private set; } =
    [
        new()
        {
            DisplayName = "Все",
            Type = SelectedSortType.None,
            TaskSorter = null
        },
        new()
        {
            DisplayName = "Имя: А-Я",
            Type = SelectedSortType.ByNameAToZ,
            TaskSorter = new SortByNameAToZ()
        },
        new()
        {
            DisplayName = "Имя: Я-А",
            Type = SelectedSortType.ByNameZToA,
            TaskSorter = new SortByNameZToA()
        },
        new()
        {
            DisplayName = "Статус: делаю",
            Type = SelectedSortType.ByStatusFalse,
            TaskSorter = new SortByStatusFalse()
        },
        new()
        {
            DisplayName = "Статус: сделано",
            Type = SelectedSortType.ByStatusTrue,
            TaskSorter = new SortByStatusTrue()
        }
    ];
    public ObservableCollection<ObservableTaskModel> Tasks { get; set; } = service.GetTasks();
    
    private ObservableTaskModel? _selectedTask;
    
    public ObservableTaskModel? SelectedTask
    {
        get => _selectedTask;
        set
        {
            if (_selectedTask == value)
                return;
            
            _selectedTask = value;
            OnPropertyChanged();
        }
    }
    
    private SelectedSort _selectedTypeSort;

    public SelectedSort SelectedTypeSort
    {
        get => _selectedTypeSort;
        set
        {
            if (_selectedTypeSort == value)
                return;

            _selectedTypeSort = value;
            OnPropertyChanged();
        }
    }

    private string? _findByNameTitle;

    public string? FindByNameTitle
    {
        get => _findByNameTitle;
        set
        {
            if (_findByNameTitle == value)
                return;

            _findByNameTitle = value;
            OnPropertyChanged();
        }
    }

    public void CancelTask() => SelectedTask = null;
}