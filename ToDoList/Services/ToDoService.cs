using System.Collections.ObjectModel;
using ToDoList.Models;

namespace ToDoList.Services;

public class ToDoService : IToDoService
{
    private ObservableCollection<ToDoTask> _tasks = [];

    public ObservableCollection<ToDoTask> GetTasks()
    {
        return _tasks;
    }

    public void AddTask(ToDoTask task)
    {
        _tasks.Add(task);
    }

    public void DeleteTask(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            _tasks.Remove(task);
        }
    }
}