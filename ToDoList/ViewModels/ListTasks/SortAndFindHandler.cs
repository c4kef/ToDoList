using ToDoList.Models;
using ToDoList.Services;
using ToDoList.ViewModels.ListTasks.FilterAndSort;

namespace ToDoList.ViewModels.ListTasks;

public class SortAndFindHandler(
    IToDoService service,
    ITaskFilter taskFilter)
{
    public void HandlePropertyChanged(TaskSortFinder sortFinder, string? propertyName)
    {
        if (propertyName is not (nameof(TaskSortFinder.SelectedTypeSort) or nameof(TaskSortFinder.FindByNameTitle)))
            return;

        if (sortFinder.SelectedTypeSort.Type == SelectedSortType.None &&
            string.IsNullOrEmpty(sortFinder.FindByNameTitle))
        {
            service.UpdateListTasks(q => q.OrderByDescending(task => task.Date));
            return;
        }

        service.UpdateListTasks((Func<IQueryable<TaskModel>, IQueryable<TaskModel>>)QueryBuilder);
        return;

        IQueryable<TaskModel> QueryBuilder(IQueryable<TaskModel> query)
        {
            query = taskFilter.ApplyFilter(query, sortFinder.FindByNameTitle);

            if (sortFinder.SelectedTypeSort.TaskSorter != null)
                query = sortFinder.SelectedTypeSort.TaskSorter.ApplySort(query);

            return query;
        }
    }
}