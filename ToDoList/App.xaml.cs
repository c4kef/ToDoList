using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.EntityFrameworkCore;
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
    private ServiceCollection? ServiceCollection { get; set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        ServiceCollection = new ServiceCollection();
        ConfigureServices(ServiceCollection);
        ServiceProvider = ServiceCollection.BuildServiceProvider();
        SetupDatabase();
        
        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
    
    private void SetupDatabase()
    {
        if (ServiceCollection is null || ServiceProvider is null)
            throw new NullReferenceException("Сервисы не были инициализированы, настройка базы данных невозможна");
        
        var context = ServiceProvider.GetService<DatabaseContext>();
        var database = context!.Database;
        
        var currentDbVersion = database.SqlQueryRaw<long>("PRAGMA user_version")
            .AsEnumerable().FirstOrDefault();
    
        if(DatabaseContext.VersionDatabase > currentDbVersion)
        {
            switch (currentDbVersion)
            {
                default://Пока при любой версии инициализируем с нуля базу
                    database.EnsureCreated();
                    break;
            }
        }
        
        database.ExecuteSqlRaw($"PRAGMA user_version={DatabaseContext.VersionDatabase}");
    }
    
    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IToDoService, ToDoService>();
        services.AddSingleton<ITaskFactory, TaskFactory>();
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<DatabaseContext>();
        
        services.AddTransient<TaskModel>();
        services.AddTransient<ObservableTaskModel>();
        services.AddTransient<TaskViewModel>();

        services.AddTransient<TaskService>();
        services.AddTransient<TaskCommandService>();
        services.AddTransient<TaskViewCommands>();

        services.AddTransient<MainWindow>(); 
    }
}