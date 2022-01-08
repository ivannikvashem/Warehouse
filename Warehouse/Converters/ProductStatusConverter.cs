using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Warehouse.Converters
{
    public class ProductStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int status = (int)value;
            if (status == 0)
            {
                //Brush brush = new SolidColorBrush(Color.FromRgb(166, 16, 0));
                //return brush;
                return Brushes.Red;
            }
            else if (status < 10)
            {
                //Brush brush = new SolidColorBrush(Color.FromRgb(255, 159, 0));
                //return brush;
                return Brushes.Yellow;
            }
            else
            {
                return Brushes.Green;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
