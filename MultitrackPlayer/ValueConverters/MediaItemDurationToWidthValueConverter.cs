using System;
using System.Globalization;
using System.Windows.Data;
using MultitrackPlayer.Controls;

namespace MultitrackPlayer.ValueConverters
{
    public class MediaItemDurationToWidthValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var duration = (TimeSpan)values[0];
            var zoomFactor = (double)values[1];
            const int millisecondsPerPixel = TimeRuler.MillisecondsPerPixel;

            return duration.TotalMilliseconds / (millisecondsPerPixel / zoomFactor);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
