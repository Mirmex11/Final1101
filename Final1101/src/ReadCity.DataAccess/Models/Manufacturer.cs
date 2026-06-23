using System.ComponentModel.DataAnnotations.Schema;

namespace ReadCity.DataAccess.Models
{
    /// <summary>
    /// Производителью
    /// </summary>
    [Table("Manufacturer")]
    public class Manufacturer
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
