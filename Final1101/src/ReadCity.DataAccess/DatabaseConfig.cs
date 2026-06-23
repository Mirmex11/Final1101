using Microsoft.Data.SqlClient;
using ReadCity.DataAccess.ConnectionFactory;

namespace ReadCity.DataAccess
{
    /// <summary>
    /// Настройки подключения к базе данных.
    /// </summary>
    public static class DatabaseConfig
    {
        public static string Server { get; set; } = "localhost\\SQLEXPRESS01"; //mssql

        public static string Database { get; set; } = "master"; //ispp4113

        //public static string UserId { get; set; } = "ispp4113";

        //public static string Password { get; set; } = "4113";

        public static string ConnectionString
        {
            get
            {
                var builder = new SqlConnectionStringBuilder
                {
                    DataSource = Server,
                    InitialCatalog = Database,
                    //UserID = UserId,
                    //Password = Password,
                    IntegratedSecurity = true,
                    TrustServerCertificate = true,
                    ConnectTimeout = 5
                };
                return builder.ConnectionString;
            }
        }

        /// <summary>
        /// Фабрика подключений к серверу.
        /// </summary>
        /// <returns></returns>
        public static IDbConnectionFactory CreateFactory() => new MSSqlConnectionFactory(ConnectionString);

        /// <summary>
        /// Проверка подключения к серверу.
        /// </summary>
        /// <returns></returns>
        public static bool TestConnection()
        {
            try
            {
                using var connection = CreateFactory().CreateConnection();
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
