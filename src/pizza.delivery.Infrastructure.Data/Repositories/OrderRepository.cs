using Microsoft.EntityFrameworkCore;
using pizza.delivery.Domain.Models;
using pizza.delivery.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizza.delivery.Infrastructure.Data.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly PizzaDeliveryDbContext _context;

        public OrderRepository(PizzaDeliveryDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IList<Order>> GetOrdersAllAsync()
        {
            var orders = await _context.Orders.Include(x => x.Client).ToListAsync();

            return orders;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            var order = await _context.Orders.Include(x => x.Client).Where(x => x.Id == id).SingleOrDefaultAsync();

            return order;
        }
    }
}