using System.Collections.ObjectModel;
using ToDoList.Models;

namespace ToDoList.Services;

public interface IToDoService
{
    //Формально линковщик
    ObservableCollection<ObservableTaskModel> GetTasks();
    void UpdateTasks();
    void AddTask(TaskModel taskModel);
    void DeleteTask(TaskModel taskModel);
    void UpdateTask(TaskModel taskModel);
}
