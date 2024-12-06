using System.ComponentModel;
using System.Windows.Controls;
using ToDoList.Models;

namespace ToDoList.Views;

public partial class ListTasks : UserControl
{
    public ListTasks()
    {
        InitializeComponent();
        var people = new BindingList<ToDoTask>
        {
            new ToDoTask { Id = new Random().Next(0, 10000), Title = "Alice", Description = "Описание 1", IsCompleted  = false },
            new ToDoTask { Id = new Random().Next(0, 10000), Title = "Alice1 fjdsajksadfjkdfsajkdasfjkdasfjkadsfkjdasfkjafsdjaksfd", Description = "Описание 2", IsCompleted  = true },
            new ToDoTask { Id = new Random().Next(0, 10000), Title = "Alice2", Description = "Описание 3", IsCompleted  = false },
            new ToDoTask { Id = new Random().Next(0, 10000), Title = "Alice2", Description = "Описание 3", IsCompleted  = false },
            new ToDoTask { Id = new Random().Next(0, 10000), Title = "Alice2", Description = "Описание 3", IsCompleted  = false },
            new ToDoTask { Id = new Random().Next(0, 10000), Title = "Alice2", Description = "Описание 3", IsCompleted  = false },
            new ToDoTask { Id = new Random().Next(0, 10000), Title = "Alice2", Description = "Описание 3", IsCompleted  = false },
            new ToDoTask { Id = new Random().Next(0, 10000), Title = "Alice2", Description = "Описание 3", IsCompleted  = false },
            new ToDoTask { Id = new Random().Next(0, 10000), Title = "Alice2", Description = "Описание 3", IsCompleted  = false },
            new ToDoTask { Id = new Random().Next(0, 10000), Title = "Alice2", Description = "Описание 3", IsCompleted  = false },
            new ToDoTask { Id = new Random().Next(0, 10000), Title = "Alice2", Description = "Описание 3", IsCompleted  = false },
            new ToDoTask { Id = new Random().Next(0, 10000), Title = "Alice2", Description = "Описание 3", IsCompleted  = false },
            new ToDoTask { Id = new Random().Next(0, 10000), Title = "Alice2", Description = "Описание 3", IsCompleted  = false },
            new ToDoTask { Id = new Random().Next(0, 10000), Title = "Alice2", Description = "Описание 3", IsCompleted  = false },
            new ToDoTask { Id = new Random().Next(0, 10000), Title = "Alice2", Description = "Описание 3", IsCompleted  = false },
            new ToDoTask { Id = new Random().Next(0, 10000), Title = "Alice2", Description = "Описание 3", IsCompleted  = false },
            new ToDoTask { Id = new Random().Next(0, 10000), Title = "Alice2", Description = "Описание 3", IsCompleted  = false },
            new ToDoTask { Id = new Random().Next(0, 10000), Title = "Alice2", Description = "Описание 3", IsCompleted  = false },
        };

        // Установка DataContext для привязки
        DataContext = new { ToDoTasks = people };
    }
}