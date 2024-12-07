using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using ToDoList.Models;
using ToDoList.Models.Interface;
using ToDoList.Services;

namespace ToDoList.ViewModels.ContentControl;

public class TaskViewModel
{
    private TaskCommandService TaskCommandService { get; }

    public TaskViewModel(TaskCommandService taskCommandService)
    {
        TaskCommandService = taskCommandService;
        AddCommand = TaskCommandService.CreateAddCommand();
        CancelCommand = TaskCommandService.CreateCancelCommand();
        UpdateCommand = TaskCommandService.CreateUpdateCommand();
        DeleteCommand = TaskCommandService.CreateDeleteCommand();

        ObservableTaskModel = TaskCommandService.TaskViewCommands.ObservableTaskModel;
        ObservableTaskModel.Set(TaskModel.CreateEmpty(),
            new CommandModel([AddCommand, CancelCommand, UpdateCommand, DeleteCommand]));

    }

    public ObservableTaskModel ObservableTaskModel { get; }
    
    public CommandStruct AddCommand { get; set; }
    public CommandStruct CancelCommand { get; set; }
    public CommandStruct UpdateCommand { get; set; }
    public CommandStruct DeleteCommand { get; set; }
}