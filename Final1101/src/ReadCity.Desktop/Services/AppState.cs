using System.Collections.ObjectModel;
using ReadCity.DataAccess.Models;
using ReadCity.Desktop.Models;

namespace ReadCity.Desktop.Services
{
    /// <summary>
    /// Хранит текущего авторизованнго пользователя и текущий заказ.
    /// </summary>
    public static class AppState
    {
        public static User? CurrentUser { get; set; }

        public static ObservableCollection<CartItem> Cart { get; } = [];

        public static bool IsManagerOrAdmin =>
            CurrentUser is not null &&
            (CurrentUser.RoleName == "Администратор" || CurrentUser.RoleName == "Менеджер");

        public static void AddToCart(Product product)
        {
            var existing = Cart.FirstOrDefault(item => item.Product.Article == product.Article);
            if (existing is null)
            {
                Cart.Add(new CartItem(product));
            }
            else
            {
                existing.Quantity++;
            }
        }
    }
}
