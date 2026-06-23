using ReadCity.DataAccess;
using ReadCity.DataAccess.ConnectionFactory;
using ReadCity.DataAccess.Repositories;
using ReadCity.DataAccess.Services;

namespace ReadCity.Desktop.Services
{
    /// <summary>
    /// Создания сервисов для работы с бд.
    /// </summary>
    public static class AppServices
    {
        static AppServices()
        {
            var factory = DatabaseConfig.CreateFactory();

            Products = new ProductService(new ProductRepository(factory));
            Orders = new OrderService(new OrderRepository(factory));
            Auth = new AuthService(new UserRepository(factory));
            Lookups = new LookupRepository(factory);
        }

        public static ProductService Products { get; }

        public static OrderService Orders { get; }

        public static AuthService Auth { get; }

        public static LookupRepository Lookups { get; }
    }
}
