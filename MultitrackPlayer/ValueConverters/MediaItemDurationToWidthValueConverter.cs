using System;
using System.Globalization;
using System.Windows.Data;

namespace MultitrackPlayer.ValueConverters
{
    public class MediaItemDurationToWidthValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var duration = (TimeSpan)values[0];
            var zoomFactor = (double)values[1];
            var millisecondsPerPixel = (int)values[2];

            return duration.TotalMilliseconds / (millisecondsPerPixel / zoomFactor);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
