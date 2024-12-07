using System.Windows.Input;

namespace ToDoList.Models.Interface;

public readonly record struct CommandStruct(string Name, ICommand Command)
{
    public string Name { get; } = Name;
    public ICommand Command { get; } = Command;
}

public interface ICommandHandler
{
    CommandStruct[] Commands { get; }
    void UpdateStateCommands();
    void UpdateStateCommand(string name);
    CommandStruct GetCommand(string name);
}