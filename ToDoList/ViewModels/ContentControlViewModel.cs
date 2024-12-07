using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using ToDoList.Models;
using ToDoList.Services;
using ToDoList.ViewModels.ContentControl;

namespace ToDoList.ViewModels;

public class ContentControlViewModel(TaskCommandService taskCommandService)
{
    public TaskViewModel Task { get; } = new(taskCommandService);
}