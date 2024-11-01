using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderFilteringAPI.Abstractions.IServices;
using OrderFilteringAPI.Models;

namespace OrderFilteringAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrderService _orderService;
        public OrdersController(ILogger<OrdersController> logger, IOrderService orderService) 
        { 
            _logger = logger;
            _orderService = orderService;
        }

        [HttpGet("filter")]
        public IActionResult FilterOrders([FromQuery] FilterParams filterParams)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orders = _orderService.LoadOrdersFromFile();
            var filterOrders = _orderService.FilterOrders(orders, filterParams.CityDistrict, filterParams.FirstDeliveryDateTime);
            if (!filterOrders.Any())
            {
                _logger.LogWarning("Не найдено заказов, удовлетворяющих условиям фильтрации.");
                return NotFound("Нет заказов для доставки в заданный район и время");
            }
            return Ok(filterOrders);
        }
    }
}
