using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfImageList
{
    public class ImageSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string filePath = value as string;
            if (filePath == null)
            {
                return DependencyProperty.UnsetValue;
            }
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(filePath);
            image.DecodePixelHeight = 100;
            image.DecodePixelWidth = 100;
            image.EndInit();
            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
