using pizza.delivery.Application.Models.Requests;
using pizza.delivery.Application.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pizza.delivery.Application.Services.Interfaces
{
    public interface IOrderAppService : IAppServiceBase
    {
        Task<IEnumerable<OrderResult>> GetAllOrdersAsync();
        Task<OrderResult> GetOrderByIdAsync(int id);
        Task<OrderResult> CreateOrderAsync(CreateOrderRequest createRequest);
        Task<OrderResult> UpdateOrderAsync(int id, UpdateOrderRequest UpdateRequest);
        Task DeleteOrderAsync(int id);
    }
}