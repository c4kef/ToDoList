using CommunityToolkit.Mvvm.Input;
using ToDoList.Models.Interface;
using ToDoList.ViewModels.ContentControl;

namespace ToDoList.Services;

public class TaskCommandService(TaskViewCommands taskViewCommands)
{
    public readonly TaskViewCommands TaskViewCommands = taskViewCommands;

    public CommandStruct CreateAddCommand()
    {
        return new CommandStruct(nameof(ViewModels.ContentControl.TaskViewCommands.AddTask), 
            new RelayCommand(TaskViewCommands.AddTask, 
                () => TaskViewCommands.ObservableTaskModel.IsFilledTitleAndDescription));
    }

    public CommandStruct CreateCancelCommand()
    {
        return new CommandStruct(nameof(ViewModels.ContentControl.TaskViewCommands.CancelTask),
            new RelayCommand(TaskViewCommands.CancelTask,
                () => TaskViewCommands.ObservableTaskModel.IsExistTask && TaskViewCommands.ObservableTaskModel.IsFilledTitleAndDescription));
    }

    public CommandStruct CreateUpdateCommand()
    {
        return new CommandStruct(nameof(ViewModels.ContentControl.TaskViewCommands.UpdateTask),
            new RelayCommand(TaskViewCommands.UpdateTask,
                () => TaskViewCommands.ObservableTaskModel.IsExistTask && TaskViewCommands.ObservableTaskModel.IsFilledTitleAndDescription));
    }

    public CommandStruct CreateDeleteCommand()
    {
        return new CommandStruct(nameof(ViewModels.ContentControl.TaskViewCommands.DeleteTask),
            new RelayCommand(TaskViewCommands.DeleteTask,
                () => TaskViewCommands.ObservableTaskModel.IsExistTask && TaskViewCommands.ObservableTaskModel.IsFilledTitleAndDescription));
    }
}
