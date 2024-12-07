using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.ViewModels.ContentControl;

public class TaskViewCommands(TaskService taskService, ObservableTaskModel observableTaskModel)
{
    public readonly ObservableTaskModel ObservableTaskModel = observableTaskModel;

    public void AddTask()
    {
        // Используем значение из ObservableTaskModel
        if (ObservableTaskModel.IsFilledTitleAndDescription)
        {
            taskService.AddTask(ObservableTaskModel.Get());  // Передаем модель в сервис для добавления задачи
        }
    }

    public void CancelTask()
    {
        // Логика отмены задачи
        if (ObservableTaskModel is { IsExistTask: true, IsFilledTitleAndDescription: true })
        {
            //_taskService.CancelTask(_observableTaskModel);  // Отмена задачи
        }
    }

    public void UpdateTask()
    {
        // Логика обновления задачи
        if (ObservableTaskModel is { IsExistTask: true, IsFilledTitleAndDescription: true })
        {
            //_taskService.UpdateTask(_observableTaskModel);  // Обновление задачи
        }
    }

    public void DeleteTask()
    {
        // Логика удаления задачи
        if (ObservableTaskModel is { IsExistTask: true, IsFilledTitleAndDescription: true })
        {
            //_taskService.DeleteTask(_observableTaskModel);  // Удаление задачи
        }
    }
}
