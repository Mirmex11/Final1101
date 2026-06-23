using System.ComponentModel.DataAnnotations.Schema;

namespace ReadCity.DataAccess.Models
{
    /// <summary>
    /// Единица измерения товара.
    /// </summary>
    [Table("Unit")]
    public class Unit
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
