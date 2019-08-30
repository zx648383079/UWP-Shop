using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace ZoDream.Shop.Converters
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var imageUrl = (string)value;
            if (string.IsNullOrEmpty(imageUrl))
            {
                return new BitmapImage();
            }
            else
            {
                if (!imageUrl.StartsWith("http") && !imageUrl.StartsWith("ms-appx:"))
                {
                    imageUrl = string.Concat("ms-appx:///", imageUrl);
                }
            }
            return imageUrl;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
