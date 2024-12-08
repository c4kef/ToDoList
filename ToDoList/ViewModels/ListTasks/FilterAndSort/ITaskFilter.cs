using ToDoList.Models;

namespace ToDoList.ViewModels.ListTasks.FilterAndSort;

public interface ITaskFilter
{
    IQueryable<TaskModel> ApplyFilter(IQueryable<TaskModel> query, string? filterText);
}
