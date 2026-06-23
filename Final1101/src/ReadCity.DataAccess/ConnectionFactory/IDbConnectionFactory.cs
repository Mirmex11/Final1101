using System.Data;

namespace ReadCity.DataAccess.ConnectionFactory
{
    /// <summary>
    /// Фабрика подключения к базе данных.
    /// </summary>
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
