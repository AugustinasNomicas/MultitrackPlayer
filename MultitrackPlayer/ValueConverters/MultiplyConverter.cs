using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MultitrackPlayer.ValueConverters
{
    class MultiplyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double parsedValue;
            double parsedParameter;
            if (double.TryParse(value.ToString(), out parsedValue) && double.TryParse(parameter.ToString(), out parsedParameter))
            {
                return parsedValue * parsedParameter;
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
