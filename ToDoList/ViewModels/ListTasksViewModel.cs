﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.ViewModels;

public class ListTasksViewModel(IToDoService service) : INotifyPropertyChanged
{
    private ToDoTask? _selectedTask;

    public ToDoTask? SelectedTask
    {
        get => _selectedTask;
        set
        {
            if (_selectedTask != null && _selectedTask == value)
                return;
            
            _selectedTask = value;
            OnPropertyChanged(nameof(SelectedTask));
        }
    }
    
    public ObservableCollection<ToDoTask> Tasks { get; set; } = service.GetTasks();
    
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}