using System.Collections.ObjectModel;
using ToDoList.Models;

namespace ToDoList.Services;

public interface IToDoService
{
    //Формально линковщик
    ObservableCollection<ObservableTaskModel> GetTasks();
    void AddTask(TaskModel taskModel);
    void DeleteTask(int id);
}
