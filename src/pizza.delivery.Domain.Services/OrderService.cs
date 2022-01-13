using pizza.delivery.Domain.Models;
using pizza.delivery.Domain.Services.Interfaces;
using pizza.delivery.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pizza.delivery.Domain.Services
{
    public class OrderService : ServiceBase<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository) : base(orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<IList<Order>> GetOrdersAllAsync()
        {
            var orders = await _orderRepository.GetOrdersAllAsync().ConfigureAwait(continueOnCapturedContext: false);

            return orders;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            var order = await _orderRepository.GetOrderByIdAsync(id).ConfigureAwait(continueOnCapturedContext: false);

            return order;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            var result = await _orderRepository.CreateAsync(order).ConfigureAwait(continueOnCapturedContext: false);

            return result;
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            var result = await _orderRepository.UpdateAsync(order).ConfigureAwait(continueOnCapturedContext: false);

            return result;
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _orderRepository.DeleteAsync(id).ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}