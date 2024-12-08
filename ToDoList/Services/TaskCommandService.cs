using CommunityToolkit.Mvvm.Input;
using ToDoList.Custom;
using ToDoList.Models.Interface;
using ToDoList.ViewModels.ContentControl;

namespace ToDoList.Services;

public class TaskCommandService(TaskViewCommands taskViewCommands)
{
    public readonly TaskViewCommands TaskViewCommands = taskViewCommands;

    public CommandStruct CreateAddCommand(Action? action = null)
    {
        return new CommandStruct(nameof(ViewModels.ContentControl.TaskViewCommands.AddTask), 
            new RelayCommand(() =>
                {
                    TaskViewCommands.AddTask();
                    action?.Invoke();
                    Native.MyMessageBox("Задача добавлена", "Уведомление");
                }, 
                () => TaskViewCommands.ObservableTaskModel.IsFilledTitleAndDescription));
    }

    public CommandStruct CreateCancelCommand(Action? action = null)
    {
        return new CommandStruct(nameof(ViewModels.ContentControl.TaskViewCommands.CancelTask),
            new RelayCommand(() =>
                {
                    TaskViewCommands.CancelTask();
                    action?.Invoke();
                },
                () => TaskViewCommands.ObservableTaskModel is { IsExistTask: true, IsFilledTitleAndDescription: true }));
    }

    public CommandStruct CreateUpdateCommand(Action? action = null)
    {
        return new CommandStruct(nameof(ViewModels.ContentControl.TaskViewCommands.UpdateTask),
            new RelayCommand(() =>
                {
                    TaskViewCommands.UpdateTask();
                    action?.Invoke();
                    Native.MyMessageBox("Вы обновили детали задачи", "Уведомление");
                },
                () => TaskViewCommands.ObservableTaskModel is { IsExistTask: true, IsFilledTitleAndDescription: true }));
    }

    public CommandStruct CreateDeleteCommand(Action? action = null)
    {
        return new CommandStruct(nameof(ViewModels.ContentControl.TaskViewCommands.DeleteTask),
            new RelayCommand(() =>
                {
                    TaskViewCommands.DeleteTask();
                    action?.Invoke();
                    Native.MyMessageBox("Вы удалили задачу", "Уведомление");
                },
                () => TaskViewCommands.ObservableTaskModel is { IsExistTask: true, IsFilledTitleAndDescription: true }));
    }
}
