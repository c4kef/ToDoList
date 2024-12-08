using ToDoList.Models;

namespace ToDoList.ViewModels.ListTasks.FilterAndSort;

public class TaskFilter : ITaskFilter
{
    public IQueryable<TaskModel> ApplyFilter(IQueryable<TaskModel> query, string? filterText)
    {
        if (!string.IsNullOrEmpty(filterText))
        {
            query = query.AsEnumerable()
                .Where(task => task.Title.Contains(filterText, StringComparison.CurrentCultureIgnoreCase))
                .AsQueryable();
        }
        return query;
    }
}
