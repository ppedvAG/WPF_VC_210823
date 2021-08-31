using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace M11_UserControls
{
    internal class DoublesToBrushConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            byte alpha = (byte)(double)values[3];
            byte red = (byte)(double)values[0];
            byte green = (byte)(double)values[1];
            byte blue = (byte)(double)values[2];

            var result = new SolidColorBrush(Color.FromArgb(alpha, red, green, blue));

            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
