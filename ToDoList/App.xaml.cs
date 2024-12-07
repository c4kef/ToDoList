using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Models;
using ToDoList.Services;
using ToDoList.ViewModels;
using ToDoList.ViewModels.ContentControl;
using TaskFactory = ToDoList.Services.TaskFactory;//Немного испортил имя

namespace ToDoList;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IServiceProvider? ServiceProvider { get; set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        ServiceProvider = serviceCollection.BuildServiceProvider();

        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
    
    private static void ConfigureServices(IServiceCollection services)
    {
        
        services.AddSingleton<IToDoService, ToDoService>();
        services.AddSingleton<ITaskFactory, TaskFactory>();
        services.AddSingleton<MainViewModel>();

        // Регистрация зависимостей
        services.AddTransient<TaskModel>();  // Регистрация TaskModel
        services.AddTransient<ObservableTaskModel>(); // Регистрация ObservableTaskModel
        services.AddTransient<TaskViewModel>();

        // Регистрируем другие зависимости
        services.AddTransient<TaskService>();
        services.AddTransient<TaskCommandService>();
        services.AddTransient<TaskViewCommands>();

        services.AddTransient<MainWindow>(); 
    }
}