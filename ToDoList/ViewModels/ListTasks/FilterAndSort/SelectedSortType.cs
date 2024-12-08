namespace ToDoList.ViewModels.ListTasks.FilterAndSort;

public record struct SelectedSort
{
    public ITaskSorter? TaskSorter { get; set; }
    public SelectedSortType Type { get; set; }
    public string DisplayName { get; set; }
}

public enum SelectedSortType
{
    None,
    ByNameAToZ,
    ByNameZToA,
    ByStatusTrue,
    ByStatusFalse
}