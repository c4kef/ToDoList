using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Services;
using ToDoList.ViewModels;
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

        services.AddSingleton<TaskService>();
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<MainWindow>();
    }
}