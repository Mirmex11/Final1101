using System.ComponentModel.DataAnnotations.Schema;

namespace ReadCity.DataAccess.Models
{
    /// <summary>
    /// Роль пользователя.
    /// </summary>
    [Table("Role")]
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
