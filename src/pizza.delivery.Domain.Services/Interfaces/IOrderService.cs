using System.Collections.Generic;
using System.Threading.Tasks;
using pizza.delivery.Domain.Models;

namespace pizza.delivery.Domain.Services.Interfaces
{
    public interface IOrderService : IServiceBase<Order>
    {
        Task<Order> GetOrderByIdAsync(int id);
        Task<IList<Order>> GetOrdersAllAsync();
        Task<Order> CreateOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int id);
    }
}