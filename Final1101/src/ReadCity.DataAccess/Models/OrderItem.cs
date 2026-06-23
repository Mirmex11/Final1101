using System.ComponentModel.DataAnnotations.Schema;

namespace ReadCity.DataAccess.Models
{
    /// <summary>
    /// Товар и его количество в конкретном заказе.
    /// </summary>
    [Table("OrderItem")]
    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderNumber { get; set; }

        public string ProductArticle { get; set; } = string.Empty;

        public int Quantity { get; set; }

        [NotMapped]
        public string? ProductName { get; set; }

        [NotMapped]
        public decimal Price { get; set; }

        [NotMapped]
        public decimal Sum => Price * Quantity;
    }
}
