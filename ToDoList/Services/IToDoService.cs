using System.Collections.ObjectModel;
using ToDoList.Models;

namespace ToDoList.Services;

public interface IToDoService
{
    //Формально линковщик
    ObservableCollection<ToDoTask> GetTasks();
    void AddTask(ToDoTask task);
    void DeleteTask(int id);
}
