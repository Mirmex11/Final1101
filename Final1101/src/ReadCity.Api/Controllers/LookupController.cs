using ReadCity.DataAccess.Models;
using ReadCity.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ReadCity.Api.Controllers
{
    /// <summary>
    /// API для получения справочных данных.
    /// </summary>
    /// <param name="lookupRepository"></param>
    [ApiController]
    [Route("api/[controller]")]
    public class LookupController(LookupRepository lookupRepository) : ControllerBase
    {
        private readonly LookupRepository _lookupRepository = lookupRepository;

        [HttpGet("categories")]
        public ActionResult<IReadOnlyList<Category>> GetCategories() => Ok(_lookupRepository.GetCategories());

        [HttpGet("manufacturers")]
        public ActionResult<IReadOnlyList<Manufacturer>> GetManufacturers() => Ok(_lookupRepository.GetManufacturers());

        [HttpGet("order-statuses")]
        public ActionResult<IReadOnlyList<OrderStatus>> GetOrderStatuses() => Ok(_lookupRepository.GetOrderStatuses());
    }
}
