using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ToDoList.Models;

namespace ToDoList.Services;

public class ToDoService : IToDoService
{
    private ObservableCollection<ObservableTaskModel> _tasks = [];

    public ObservableCollection<ObservableTaskModel> GetTasks()
    {
        return _tasks;
    }

    public void AddTask(TaskModel taskModel)
    {
        _tasks.Add(new ObservableTaskModel(new TaskModel
        {
            Id = taskModel.Id,
            Description = taskModel.Description,
            IsCompleted = taskModel.IsCompleted,
            Title = taskModel.Title
        }));
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