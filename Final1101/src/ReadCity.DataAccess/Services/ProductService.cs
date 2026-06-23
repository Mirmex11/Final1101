using ReadCity.DataAccess.Models;
using ReadCity.DataAccess.Repositories;

namespace ReadCity.DataAccess.Services
{
    /// <summary>
    /// Получение данных, поиск, фильтрация и сортировка товаров.
    /// </summary>
    /// <param name="productRepository"></param>
    public class ProductService(ProductRepository productRepository)
    {
        private readonly ProductRepository _productRepository = productRepository;

        public IReadOnlyList<Product> GetAll() => _productRepository.GetAll();

        public int GetTotalCount() => _productRepository.GetTotalCount();

        public Product? GetByArticle(string article) => _productRepository.GetByArticle(article);

        /// <summary>
        /// Применяет к списку товаров поиск, фильтрацию и сортировку.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="query"></param>
        /// <returns>Списк товаров после поиска, фильтрации и сортировки</returns>
        public IReadOnlyList<Product> Apply(IEnumerable<Product> source, ProductQuery query)
        {
            IEnumerable<Product> result = source;

            if (!string.IsNullOrWhiteSpace(query.SearchText))
            {
                var text = query.SearchText.Trim();
                result = result.Where(product =>
                    product.Name.Contains(text, StringComparison.OrdinalIgnoreCase));
            }

            if (query.ManufacturerId.HasValue)
            {
                result = result.Where(product => product.ManufacturerId == query.ManufacturerId.Value);
            }

            if (query.MinPrice.HasValue)
            {
                result = result.Where(product => product.Price >= query.MinPrice.Value);
            }

            if (query.MaxPrice.HasValue)
            {
                result = result.Where(product => product.Price <= query.MaxPrice.Value);
            }

            result = query.SortField switch
            {
                ProductSortField.Price => query.SortDescending
                    ? result.OrderByDescending(product => product.Price)
                    : result.OrderBy(product => product.Price), _ => query.SortDescending
                    ? result.OrderByDescending(product => product.Name)
                    : result.OrderBy(product => product.Name)
            };

            return result.ToList();
        }
    }
}
