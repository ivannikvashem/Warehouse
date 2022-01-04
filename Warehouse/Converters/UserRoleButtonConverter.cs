using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Warehouse.Converters
{
    public class UserRoleButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string role = ApplicationContext.Status.ToString();
            if (role == "Администратор") { return Visibility.Visible; }

            else if (role == "Менеджер") { return Visibility.Collapsed; }

            else { return true; }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
