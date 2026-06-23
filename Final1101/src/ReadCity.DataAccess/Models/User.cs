using System.ComponentModel.DataAnnotations.Schema;

namespace ReadCity.DataAccess.Models
{
    /// <summary>
    /// Пользователь системы.
    /// </summary>
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Login { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public int RoleId { get; set; }

        [NotMapped]
        public string? RoleName { get; set; }
    }
}
