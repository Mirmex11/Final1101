using ReadCity.Api.Dtos;
using ReadCity.DataAccess.Models;
using ReadCity.DataAccess.Services;
using Microsoft.AspNetCore.Mvc;

namespace ReadCity.Api.Controllers
{
    /// <summary>
    /// API для получения и редактирования заказов.
    /// </summary>
    /// <param name="orderService"></param>
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController(OrderService orderService) : ControllerBase
    {
        private readonly OrderService _orderService = orderService;

        [HttpGet]
        public ActionResult<IReadOnlyList<Order>> GetAll() => Ok(_orderService.GetAllOrders());

        [HttpGet("{number:int}")]
        public ActionResult<Order> GetByNumber(int number)
        {
            var order = _orderService.GetOrder(number);
            return order is null ? NotFound() : Ok(order);
        }

        [HttpPost]
        public ActionResult<Order> Create(CreateOrderRequest request)
        {
            if (request.Items is null || request.Items.Count == 0)
            {
                return BadRequest("Заказ должен содержать хотя бы одну позицию.");
            }

            var items = request.Items
                .Select(item => new OrderItem { ProductArticle = item.ProductArticle, Quantity = item.Quantity })
                .ToList();

            var order = _orderService.CreateOrder(items, request.UserId);
            return CreatedAtAction(nameof(GetByNumber), new { number = order.Number }, order);
        }

        [HttpPut("{number:int}")]
        public IActionResult Update(int number, UpdateOrderRequest request)
        {
            if (_orderService.GetOrder(number) is null)
            {
                return NotFound();
            }

            _orderService.UpdateDeliveryAndStatus(number, request.DeliveryDate, request.StatusId);
            return NoContent();
        }
    }
}
