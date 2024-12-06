using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.ViewModels.ContentControl;

public class TaskViewModel : INotifyPropertyChanged
{
    private readonly TaskService _taskService;

    public TaskViewModel(TaskService taskService)
    {
        _taskService = taskService;
        AddCommand = new RelayCommand(
            execute: AddTask,
            canExecute: CanAddTask
        );
    }
    
    private string? _title;
    public string? Title
    {
        get => _title;
        set
        {
            if (_title == value
                || (value ?? string.Empty).Length < ToDoTask.TitleMaxLength) 
                return;
            
            _title = value ?? string.Empty;
            OnPropertyChanged(nameof(Title));
            UpdateStateCommand();
        }
    }

    private string? _description;

    public string? Description
    {
        get => _description;
        set
        {
            if (_description == value 
                || (value ?? string.Empty).Length < ToDoTask.DescriptionMaxLength) 
                return;
            
            _description = value ?? string.Empty;
            OnPropertyChanged(nameof(Description));
            UpdateStateCommand();
        }
    }

    private bool _isCompleted;
    public bool IsCompleted
    {
        get => _isCompleted;
        set
        {
            if (_isCompleted == value) return;
            _isCompleted = value;
            OnPropertyChanged(nameof(IsCompleted));
        }
    }

    public ICommand AddCommand { get; }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private void AddTask()
    {
        if (!CanAddTask())
            throw new InvalidOperationException("Невозможно добавить задачу: проверьте заголовок и описание.");

        _taskService.AddTask(Title ?? throw new NullReferenceException("Заголовок не может быть пустым."),
            Description ?? throw new NullReferenceException("Описание не может быть пустым."),
            IsCompleted);

        ClearFields();
    }

    private void ClearFields()
    {
        Title = string.Empty;
        Description = string.Empty;
        IsCompleted = false;
    }

    private void UpdateStateCommand() =>
        (AddCommand as RelayCommand ?? throw new NullReferenceException("Ссылка для обновления была пуста"))
        .NotifyCanExecuteChanged();
    
    private bool CanAddTask() => !string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(Description);
}
