using System.ComponentModel.DataAnnotations.Schema;

namespace ReadCity.DataAccess.Models
{
    /// <summary>
    /// Статус заказа.
    /// </summary>
    [Table("OrderStatus")]
    public class OrderStatus
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
