using ToDoList.Models;
using ToDoList.Models.Interface;
using ToDoList.Services;
using ToDoList.ViewModels.ContentControl;

namespace ToDoList.ViewModels;

public class ContentControlViewModel
{
    private TaskCommandService TaskCommandService { get; }

    public ContentControlViewModel(TaskCommandService taskCommandService)
    {
        TaskCommandService = taskCommandService;
        AddCommand = TaskCommandService.CreateAddCommand();
        UpdateCommand = TaskCommandService.CreateUpdateCommand();
        DeleteCommand = TaskCommandService.CreateDeleteCommand();

        ObservableTaskModel = TaskCommandService.TaskViewCommands.ObservableTaskModel;
        ObservableTaskModel.Set(TaskModel.CreateEmpty(), [
            AddCommand, UpdateCommand, DeleteCommand
        ]);
    }

    public ObservableTaskModel ObservableTaskModel { get; }
    
    public CommandStruct AddCommand { get; set; }
    public CommandStruct UpdateCommand { get; set; }
    public CommandStruct DeleteCommand { get; set; }
}