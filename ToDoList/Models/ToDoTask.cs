using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ToDoList.Models;

public class ToDoTask : ObservableObject
{
    /// <summary>
    /// Максимальная длина заголовка
    /// </summary>
    public const int TitleMaxLength = 120;
    /// <summary>
    /// Максимальная длина описания
    /// </summary>
    public const int DescriptionMaxLength = 1024;
    
    public required int Id { get; set; }

    //Без понятия, не думаю что заголовок будет > 120 символов
    [MaxLength(TitleMaxLength)] public required string Title { get; set; }

    //Дадим возможность передать 1024 символа
    [MaxLength(DescriptionMaxLength)] public required string Description { get; set; }
    public required bool IsCompleted { get; set; }
}