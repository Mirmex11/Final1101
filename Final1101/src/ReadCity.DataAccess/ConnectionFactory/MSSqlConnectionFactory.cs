using System.Data;
using Microsoft.Data.SqlClient;

namespace ReadCity.DataAccess.ConnectionFactory
{
    /// <summary>
    /// Фабрика подключений к серверу.
    /// </summary>
    /// <param name="connectionString"></param>
    public class MSSqlConnectionFactory(string connectionString) : IDbConnectionFactory
    {
        private readonly string _connectionString = connectionString;

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
