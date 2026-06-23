namespace ReadCity.Api.Dtos
{
    /// <summary>
    /// Запрос на вход в систему.
    /// </summary>
    /// <param name="Login"></param>
    /// <param name="Password"></param>
    public record LoginRequest(string Login, string Password);

    /// <summary>
    /// Позиция заказа в запросе на создание заказа.
    /// </summary>
    /// <param name="ProductArticle"></param>
    /// <param name="Quantity"></param>
    public record OrderItemRequest(string ProductArticle, int Quantity);

    /// <summary>
    /// Запрос на создание нового заказа.
    /// </summary>
    /// <param name="UserId"></param>
    /// <param name="Items"></param>
    public record CreateOrderRequest(int? UserId, List<OrderItemRequest> Items);

    /// <summary>
    /// Запрос на обновление даты доставки и статуса заказа.
    /// </summary>
    /// <param name="DeliveryDate"></param>
    /// <param name="StatusId"></param>
    public record UpdateOrderRequest(DateTime? DeliveryDate, int StatusId);
}
