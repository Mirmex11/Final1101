using System.ComponentModel.DataAnnotations.Schema;

namespace ReadCity.DataAccess.Models
{
    /// <summary>
    /// Товарр.
    /// </summary>
    [Table("Product")]
    public class Product
    {
        public string Article { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Author { get; set; }

        public decimal Price { get; set; }

        public int Discount { get; set; }

        public int StockQuantity { get; set; }

        public string? Photo { get; set; }

        public int UnitId { get; set; }

        public int CategoryId { get; set; }

        public int ManufacturerId { get; set; }

        [NotMapped]
        public string? CategoryName { get; set; }

        [NotMapped]
        public string? ManufacturerName { get; set; }

        [NotMapped]
        public string? UnitName { get; set; }
    }
}
