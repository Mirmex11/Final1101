using ReadCity.DataAccess.Models;
using ReadCity.DataAccess.Services;
using Microsoft.AspNetCore.Mvc;

namespace ReadCity.Api.Controllers
{
    /// <summary>
    /// API для получения данных о товарах.
    /// </summary>
    /// <param name="productService"></param>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(ProductService productService) : ControllerBase
    {
        private readonly ProductService _productService = productService;

        [HttpGet]
        public ActionResult<IReadOnlyList<Product>> GetAll() => Ok(_productService.GetAll());

        [HttpGet("{article}")]
        public ActionResult<Product> GetByArticle(string article)
        {
            var product = _productService.GetByArticle(article);
            return product is null ? NotFound() : Ok(product);
        }
    }
}
