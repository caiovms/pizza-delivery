using pizza.delivery.Domain.Models;
using pizza.delivery.Infrastructure.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pizza.delivery.Infrastructure.Data.Interfaces
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Task<IList<Order>> GetOrdersAllAsync();
        Task<Order> GetOrderByIdAsync(int id);
    }
}