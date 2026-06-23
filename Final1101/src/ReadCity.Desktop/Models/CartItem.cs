using System.ComponentModel;
using ReadCity.DataAccess.Models;

namespace ReadCity.Desktop.Models
{
    /// <summary>
    /// Хранит информацию о товаре и его количестве.
    /// </summary>
    /// <param name="product"></param>
    public class CartItem(Product product) : INotifyPropertyChanged
    {
        private int _quantity = 1;

        public Product Product { get; } = product;

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity == value)
                {
                    return;
                }
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
                OnPropertyChanged(nameof(Sum));
            }
        }

        public decimal Sum => Product.Price * Quantity;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
