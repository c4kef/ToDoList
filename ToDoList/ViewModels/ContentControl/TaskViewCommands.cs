using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.ViewModels.ContentControl;

public class TaskViewCommands(TaskService taskService, ObservableTaskModel observableTaskModel)
{
    public readonly ObservableTaskModel ObservableTaskModel = observableTaskModel;

    public void AddTask()
    {
        if (ObservableTaskModel.IsFilledTitleAndDescription)
            taskService.AddTask(ObservableTaskModel.Get());

        ObservableTaskModel.Set(TaskModel.CreateEmpty());
    }

    public void CancelTask()
    {
        if (ObservableTaskModel is not { IsExistTask: true, IsFilledTitleAndDescription: true }) return;

        ObservableTaskModel.Set(TaskModel.CreateEmpty());
    }

    public void UpdateTask()
    {
        if (ObservableTaskModel is not { IsExistTask: true, IsFilledTitleAndDescription: true }) return;
        
        taskService.UpdateTask(ObservableTaskModel.Get());
        ObservableTaskModel.Set(TaskModel.CreateEmpty());
    }

    public void DeleteTask()
    {
        if (ObservableTaskModel is not { IsExistTask: true, IsFilledTitleAndDescription: true }) return;

        taskService.DeleteTask(ObservableTaskModel.Get());
        ObservableTaskModel.Set(TaskModel.CreateEmpty());
    }
}