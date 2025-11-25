using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace konkurs {
    public class IconPathConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            string basePath = value as string;      // IconBase (/Bright/ or /Dark/)
            string fileName = parameter as string;  // "home.png"

            return new BitmapImage(new Uri(basePath + fileName, UriKind.Relative));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}