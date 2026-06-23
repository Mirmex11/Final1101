using System.ComponentModel.DataAnnotations.Schema;

namespace ReadCity.DataAccess.Models
{
    /// <summary>
    /// Категория товара.
    /// </summary>
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
