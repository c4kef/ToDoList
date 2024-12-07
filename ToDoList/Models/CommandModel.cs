using CommunityToolkit.Mvvm.Input;
using ToDoList.Models.Interface;

namespace ToDoList.Models;

public class CommandModel(CommandStruct[] commands) : ICommandHandler
{
    public CommandStruct[] Commands { get; } = commands;

    public void UpdateStateCommands()
    {
        foreach (var command in Commands)
            (command.Command as RelayCommand)!.NotifyCanExecuteChanged();
    }
    
    public void UpdateStateCommand(string name)
    {
        var command = GetCommand(name);
        (command.Command as RelayCommand)!.NotifyCanExecuteChanged();
    }

    public CommandStruct GetCommand(string name)
    {
        var command = Commands.FirstOrDefault(c => c.Name == name);
        if (command.Equals(default))
            throw new NullReferenceException("Команда не найдена");
        
        return command;
    }
}