using ACCharging.Common;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ACCharging.Shell.Converters
{
    [ValueConversion(typeof(UserGender), typeof(bool?))]
    public class UserGenderToCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Equals(value, parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                bool isChecked= (bool)value;
                if (isChecked)
                    return parameter;
            }

            return DependencyProperty.UnsetValue;
        }
    }
}
