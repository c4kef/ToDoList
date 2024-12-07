using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ToDoList.Custom;

public class BooleanToVisibilityConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not bool uiValue)
            return Visibility.Collapsed;

        var invert = parameter?.ToString() == "Invert";
        uiValue = invert ? !uiValue : uiValue;
        return uiValue ? Visibility.Visible : Visibility.Collapsed;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is Visibility visibility)
            return visibility == Visibility.Visible;
        
        return false;
    }
}