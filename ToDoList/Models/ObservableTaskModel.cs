using CommunityToolkit.Mvvm.ComponentModel;

namespace ToDoList.Models;

public class ObservableTaskModel(TaskModel taskModel) : ObservableObject
{
    private CommandModel? _commandsHelper;
    
    public int Id
    {
        get => taskModel.Id;
        set
        {
            SetProperty(taskModel.Id, value, taskModel, (u, n) => u.Id = n);
            OnPropertyChanged(nameof(IsExistTask));
            _commandsHelper?.UpdateStateCommands();
        }
    }

    public string Title
    {
        get => taskModel.Title;
        set
        {
            SetProperty(taskModel.Title, value, taskModel, (u, n) => u.Title = n);
            OnPropertyChanged(nameof(IsFilledTitleAndDescription));
            _commandsHelper?.UpdateStateCommands();
        }
    }

    public string Description
    {
        get => taskModel.Description;
        set
        {
            SetProperty(taskModel.Description, value, taskModel, (u, n) => u.Description = n);
            OnPropertyChanged(nameof(IsFilledTitleAndDescription));
            _commandsHelper?.UpdateStateCommands();
        }
    }

    public bool IsCompleted
    {
        get => taskModel.IsCompleted;
        set
        {
            SetProperty(taskModel.IsCompleted, value, taskModel, (u, n) => u.IsCompleted = n);
        }
    }
    
    public bool IsFilledTitleAndDescription => !string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(Description);
    public bool IsExistTask => Id != -1;

    public TaskModel Get() => taskModel;

    public void Set(TaskModel model, CommandModel? commandsHelper = null)
    {
        Id = model.Id;
        Title = model.Title;
        Description = model.Description;
        IsCompleted = model.IsCompleted;
        
        if (commandsHelper is not null)
            _commandsHelper = commandsHelper;
    }
}