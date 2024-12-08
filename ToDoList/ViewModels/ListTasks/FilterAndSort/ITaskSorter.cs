using ToDoList.Models;

namespace ToDoList.ViewModels.ListTasks.FilterAndSort;

public interface ITaskSorter
{
    IQueryable<TaskModel> ApplySort(IQueryable<TaskModel> query);
}
