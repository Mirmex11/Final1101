using System.Globalization;
using System.Windows.Data;

namespace ReadCity.Desktop.Helpers
{
    /// <summary>
    /// Преобразует имя файла фото товара в изображение.
    /// </summary>
    public class PhotoToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            ImageHelper.GetProductImage(value as string);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotSupportedException();
    }
}
