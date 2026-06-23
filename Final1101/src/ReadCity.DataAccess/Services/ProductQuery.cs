namespace ReadCity.DataAccess.Services
{
    /// <summary>
    /// Шаблон для сортировки списка товаров.
    /// </summary>
    public enum ProductSortField
    {
        Name,
        Price
    }

    /// <summary>
    /// Параметры поиска, фильтрации и сортировки.
    /// </summary>
    public class ProductQuery
    {
        public string? SearchText { get; set; }

        public int? ManufacturerId { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public ProductSortField SortField { get; set; } = ProductSortField.Name;

        public bool SortDescending { get; set; }
    }
}
