using Dapper;
using ReadCity.DataAccess.ConnectionFactory;
using ReadCity.DataAccess.Models;

namespace ReadCity.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий для доступа к заказам и их позициям.
    /// </summary>
    /// <param name="connectionFactory"></param>
    public class OrderRepository(IDbConnectionFactory connectionFactory)
    {
        private readonly IDbConnectionFactory _connectionFactory = connectionFactory;

        private const string SelectHeader = """
            SELECT o.Number, o.OrderDate, o.DeliveryDate, o.PickupCode, o.StatusId, o.UserId,
                   s.Name AS StatusName, u.FullName AS ClientName
            FROM Orders o
            JOIN OrderStatus s ON s.Id = o.StatusId
            LEFT JOIN Users u ON u.Id = o.UserId
            """;

        private const string SelectItems = """
            SELECT oi.Id, oi.OrderNumber, oi.ProductArticle, oi.Quantity,
                   p.Name AS ProductName,
                   p.Price AS Price
            FROM OrderItem oi
            JOIN Product p ON p.Article = oi.ProductArticle
            WHERE oi.OrderNumber = @Number
            """;

        public int GetNextNumber()
        {
            using var connection = _connectionFactory.CreateConnection();
            return connection.ExecuteScalar<int>("SELECT COALESCE(MAX(Number), 0) + 1 FROM Orders");
        }

        public void Create(Order order)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();

            connection.Execute("""
                INSERT INTO Orders (Number, OrderDate, DeliveryDate, PickupCode, StatusId, UserId)
                VALUES (@Number, @OrderDate, @DeliveryDate, @PickupCode, @StatusId, @UserId)
                """, order, transaction);

            foreach (var item in order.Items)
            {
                connection.Execute("""
                    INSERT INTO OrderItem (OrderNumber, ProductArticle, Quantity)
                    VALUES (@OrderNumber, @ProductArticle, @Quantity)
                    """,
                    new { OrderNumber = order.Number, item.ProductArticle, item.Quantity },
                    transaction);
            }

            transaction.Commit();
        }

        public Order? GetByNumber(int number)
        {
            using var connection = _connectionFactory.CreateConnection();
            var order = connection.QueryFirstOrDefault<Order>(
                $"{SelectHeader} WHERE o.Number = @Number", new { Number = number });

            if (order is null)
            {
                return null;
            }

            order.Items = connection.Query<OrderItem>(SelectItems, new { Number = number }).ToList();
            return order;
        }

        public IReadOnlyList<Order> GetAll()
        {
            using var connection = _connectionFactory.CreateConnection();
            return connection.Query<Order>($"{SelectHeader} ORDER BY o.Number DESC").ToList();
        }

        public void UpdateDeliveryAndStatus(int number, DateTime? deliveryDate, int statusId)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Execute(
                "UPDATE Orders SET DeliveryDate = @DeliveryDate, StatusId = @StatusId WHERE Number = @Number",
                new { Number = number, DeliveryDate = deliveryDate, StatusId = statusId });
        }
    }
}
