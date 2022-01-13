using Microsoft.AspNetCore.Mvc;
using pizza.delivery.Application.Models.Requests;
using pizza.delivery.Application.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace pizza.delivery.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderAppService _orderAppService;

        public OrderController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService ?? throw new ArgumentNullException(nameof(orderAppService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var orders = await _orderAppService.GetAllOrdersAsync().ConfigureAwait(continueOnCapturedContext: false);

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var order = await _orderAppService.GetOrderByIdAsync(id).ConfigureAwait(continueOnCapturedContext: false);

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateOrderRequest request)
        {
            await _orderAppService.CreateOrderAsync(request).ConfigureAwait(continueOnCapturedContext: false);

            return Ok(new { message = "Order created" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateOrderRequest request)
        {
            await _orderAppService.UpdateOrderAsync(id, request).ConfigureAwait(continueOnCapturedContext: false);

            return Ok(new { message = $"Order {id} updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _orderAppService.DeleteOrderAsync(id).ConfigureAwait(continueOnCapturedContext: false);

            return Ok(new { message = $"Order {id} deleted" });
        }
    }
}