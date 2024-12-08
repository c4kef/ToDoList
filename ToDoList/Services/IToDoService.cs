using System.Collections.ObjectModel;
using ToDoList.Models;

namespace ToDoList.Services;

public interface IToDoService
{
    //Формально линковщик
    ObservableCollection<ObservableTaskModel> GetTasks();
    void UpdateListTasks(Func<IQueryable<TaskModel>, IQueryable<TaskModel>>? sortExpression = null);
    void UpdateListTasksWithLastFilter();
    void AddTask(TaskModel taskModel);
    void DeleteTask(TaskModel taskModel);
    void UpdateTask(TaskModel taskModel);
}
