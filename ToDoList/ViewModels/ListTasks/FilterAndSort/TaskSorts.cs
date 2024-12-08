using ToDoList.Models;

namespace ToDoList.ViewModels.ListTasks.FilterAndSort;

public class SortByNameAToZ : ITaskSorter
{
    public IQueryable<TaskModel> ApplySort(IQueryable<TaskModel> query) =>
        query.AsEnumerable()
            .OrderBy(task => task.Title, StringComparer.OrdinalIgnoreCase)
            .AsQueryable();
}

public class SortByNameZToA : ITaskSorter
{
    public IQueryable<TaskModel> ApplySort(IQueryable<TaskModel> query) =>
        query.AsEnumerable()
            .OrderByDescending(task => task.Title, StringComparer.OrdinalIgnoreCase)
            .AsQueryable();
}

public class SortByStatusTrue : ITaskSorter
{
    public IQueryable<TaskModel> ApplySort(IQueryable<TaskModel> query) =>
        query.Where(task => task.IsCompleted).OrderByDescending(task => task.Date);
}

public class SortByStatusFalse : ITaskSorter
{
    public IQueryable<TaskModel> ApplySort(IQueryable<TaskModel> query) =>
        query.Where(task => !task.IsCompleted).OrderByDescending(task => task.Date);
}
