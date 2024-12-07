using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using ToDoList.Models;

namespace ToDoList.Services;

public class ToDoService(DatabaseContext context) : IToDoService
{
    private readonly ObservableCollection<ObservableTaskModel> _tasks =
        new(context.ToDoTasks.Select(taskModel => new ObservableTaskModel(taskModel)));

    public ObservableCollection<ObservableTaskModel> GetTasks() => _tasks;

    public void UpdateTasks()
    {
        _tasks.Clear();
        foreach (var observableTaskModel in context.ToDoTasks.ToList()
                     .Select(task => new ObservableTaskModel(task.ReCreate())))
            _tasks.Add(observableTaskModel);
    }

    public void AddTask(TaskModel taskModel)
    {
        taskModel.Date = DateTime.Now;
        
        _tasks.Add(new ObservableTaskModel(new TaskModel
        {
            Id = taskModel.Id,
            Description = taskModel.Description,
            IsCompleted = taskModel.IsCompleted,
            Date = taskModel.Date,
            Title = taskModel.Title
        }));
        
        context.ToDoTasks.Add(taskModel);
        context.SaveChanges();
    }

    public void DeleteTask(TaskModel taskModel)
    {
        var taskFound = context.ToDoTasks.Find(taskModel.Id);
        if (taskFound == null) 
            return;
        
        context.ToDoTasks.Remove(taskFound);
        context.SaveChanges();
    }
    
    public void UpdateTask(TaskModel taskModel)
    {
        var taskFound = context.ToDoTasks.Find(taskModel.Id);
        if (taskFound == null) 
            return;
        
        taskFound.Title = taskModel.Title;
        taskFound.Description = taskModel.Description;
        taskFound.IsCompleted = taskModel.IsCompleted;
        context.SaveChanges();
    }
}