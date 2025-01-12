using System;
using System.Globalization;
using System.Windows.Data;

namespace ValidationApp.Helpers
{
    public class PasswordToBaseValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Chuyển giá trị từ PasswordBox (value) thành string (BaseValue)
            return value?.ToString() ?? string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // ConvertBack không cần thiết trong trường hợp này
            return null;
        }
    }
}
