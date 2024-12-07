using System.Windows;
using ToDoList.ViewModels;

namespace ToDoList;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        ContentControl.DataContext = viewModel.ContentControlViewModel;
        ListTasks.DataContext = viewModel.TaskListViewModel;
    }
}