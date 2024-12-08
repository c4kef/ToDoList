using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Services;

public class ToDoService(DatabaseContext context) : IToDoService
{
    private readonly ObservableCollection<ObservableTaskModel> _tasks = [];

    public ObservableCollection<ObservableTaskModel> GetTasks() => _tasks;
    
    private Func<IQueryable<TaskModel>, IQueryable<TaskModel>>? _currentSortExpression;

    public void UpdateListTasks(Func<IQueryable<TaskModel>, IQueryable<TaskModel>>? sortExpression = null)
    {
        _tasks.Clear();
        _currentSortExpression = sortExpression;
        
        var query = context.ToDoTasks.AsNoTracking();
        if (sortExpression != null)
            query = sortExpression(query);

        foreach (var observableTaskModel in query.ToList()
                     .Select(task => new ObservableTaskModel(task)))
            _tasks.Add(observableTaskModel);
    }

    public void UpdateListTasksWithLastFilter() => UpdateListTasks(_currentSortExpression);

    public void AddTask(TaskModel taskModel)
    {
        context.ToDoTasks.Add(taskModel.ReCreate());//dto
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