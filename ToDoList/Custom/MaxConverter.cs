using System.Globalization;
using System.Windows.Data;

namespace ToDoList.Custom;

public class MaxConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is double lastViewSize)
            return lastViewSize * 0.8;
        
        return value ?? 0.0;//иногда первые значения бывают пустыми, потому игнорим
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException("Не делал");
    }
}