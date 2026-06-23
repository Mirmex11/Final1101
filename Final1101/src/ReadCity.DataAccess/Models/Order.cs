using System.ComponentModel.DataAnnotations.Schema;

namespace ReadCity.DataAccess.Models
{
    /// <summary>
    /// Заказ.
    /// </summary>
    [Table("Orders")]
    public class Order
    {
        public int Number { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public string PickupCode { get; set; } = string.Empty;

        public int StatusId { get; set; }

        public int? UserId { get; set; }

        [NotMapped]
        public string? StatusName { get; set; }

        [NotMapped]
        public string? ClientName { get; set; }

        [NotMapped]
        public List<OrderItem> Items { get; set; } = [];

        [NotMapped]
        public decimal TotalSum => Items.Sum(item => item.Sum);
    }
}
