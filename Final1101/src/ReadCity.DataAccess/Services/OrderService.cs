using ReadCity.DataAccess.Models;
using ReadCity.DataAccess.Repositories;

namespace ReadCity.DataAccess.Services
{
    /// <summary>
    /// Оформление и обработка заказов.
    /// </summary>
    /// <param name="orderRepository"></param>
    public class OrderService(OrderRepository orderRepository)
    {
        public const int StatusNew = 1;

        private readonly OrderRepository _orderRepository = orderRepository;
        private static readonly Random Random = new();

        /// <summary>
        /// Формирует и сохраняет новый заказ.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="userId"></param>
        /// <returns>Возвращает новый заказ</returns>
        public Order CreateOrder(IEnumerable<OrderItem> items, int? userId)
        {
            var order = new Order
            {
                Number = _orderRepository.GetNextNumber(),
                OrderDate = DateTime.Now.Date,
                DeliveryDate = null,
                PickupCode = GeneratePickupCode(),
                StatusId = StatusNew,
                UserId = userId,
                Items = items.ToList()
            };

            _orderRepository.Create(order);
            return order;
        }

        public static string GeneratePickupCode() => Random.Next(0, 1000).ToString("D3");

        public Order? GetOrder(int number) => _orderRepository.GetByNumber(number);

        public IReadOnlyList<Order> GetAllOrders() => _orderRepository.GetAll();

        public void UpdateDeliveryAndStatus(int number, DateTime? deliveryDate, int statusId) =>
            _orderRepository.UpdateDeliveryAndStatus(number, deliveryDate, statusId);
    }
}
