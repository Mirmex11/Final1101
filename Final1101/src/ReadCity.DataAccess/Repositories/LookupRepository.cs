using Dapper;
using ReadCity.DataAccess.ConnectionFactory;
using ReadCity.DataAccess.Models;

namespace ReadCity.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий для доступа к справочникам.
    /// </summary>
    /// <param name="connectionFactory"></param>
    public class LookupRepository(IDbConnectionFactory connectionFactory)
    {
        private readonly IDbConnectionFactory _connectionFactory = connectionFactory;

        public IReadOnlyList<Category> GetCategories()
        {
            using var connection = _connectionFactory.CreateConnection();
            return connection.Query<Category>("SELECT Id, Name FROM Category ORDER BY Name").ToList();
        }

        public IReadOnlyList<Manufacturer> GetManufacturers()
        {
            using var connection = _connectionFactory.CreateConnection();
            return connection.Query<Manufacturer>("SELECT Id, Name FROM Manufacturer ORDER BY Name").ToList();
        }

        public IReadOnlyList<Unit> GetUnits()
        {
            using var connection = _connectionFactory.CreateConnection();
            return connection.Query<Unit>("SELECT Id, Name FROM Unit ORDER BY Name").ToList();
        }

        public IReadOnlyList<OrderStatus> GetOrderStatuses()
        {
            using var connection = _connectionFactory.CreateConnection();
            return connection.Query<OrderStatus>("SELECT Id, Name FROM OrderStatus ORDER BY Id").ToList();
        }

        public IReadOnlyList<Role> GetRoles()
        {
            using var connection = _connectionFactory.CreateConnection();
            return connection.Query<Role>("SELECT Id, Name FROM Role ORDER BY Id").ToList();
        }
    }
}
