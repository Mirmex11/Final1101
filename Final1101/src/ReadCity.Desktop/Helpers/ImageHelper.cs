using System.IO;
using System.Windows.Media.Imaging;

namespace ReadCity.Desktop.Helpers
{
    /// <summary>
    /// Помощь в загрузке фото товаров.
    /// </summary>
    public static class ImageHelper
    {
        private const string PlaceholderUri = "pack://application:,,,/Resources/picture.png";

        private static readonly string ProductsDirectory =
            Path.Combine(AppContext.BaseDirectory, "Resources", "Products");

        /// <summary>
        /// Возвращает фото товара по имени файла. Если файла нет, возвращает заглушку.
        /// </summary>
        /// <param name="photo"></param>
        /// <returns>фото товара</returns>
        public static BitmapImage GetProductImage(string? photo)
        {
            if (!string.IsNullOrWhiteSpace(photo))
            {
                var path = Path.Combine(ProductsDirectory, photo);
                if (File.Exists(path))
                {
                    return Load(new Uri(path, UriKind.Absolute));
                }
            }

            return Load(new Uri(PlaceholderUri, UriKind.Absolute));
        }

        private static BitmapImage Load(Uri uri)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.UriSource = uri;
            image.EndInit();
            image.Freeze();
            return image;
        }
    }
}
