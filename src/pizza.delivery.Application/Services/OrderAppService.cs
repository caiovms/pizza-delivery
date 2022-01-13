using AutoMapper;
using pizza.delivery.Application.Models.Requests;
using pizza.delivery.Application.Models.Responses;
using pizza.delivery.Application.Resources;
using pizza.delivery.Application.Services.Interfaces;
using pizza.delivery.Domain.Models;
using pizza.delivery.Domain.Services.Interfaces;
using pizza.delivery.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizza.delivery.Application.Services
{
    public class OrderAppService : AppServiceBase, IOrderAppService
    {
        private readonly IOrderService _orderService;
        private readonly IClientService _clientService;

        public OrderAppService(IMapper mapper, IOrderService orderService, IClientService clientService) : base(mapper)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
        }

        public async Task<IEnumerable<OrderResult>> GetAllOrdersAsync()
        {
            var orders = await _orderService.GetOrdersAllAsync().ConfigureAwait(continueOnCapturedContext: false);

            if (!orders.Any())
            {
                throw new NotFoundException(ApplicationResources.OrderNotFound);
            }

            var result = Mapper.Map<IEnumerable<OrderResult>>(orders);

            return result;
        }

        public async Task<OrderResult> GetOrderByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException(ApplicationResources.InvalidRequest);
            }

            var order = await _orderService.GetOrderByIdAsync(id).ConfigureAwait(continueOnCapturedContext: false);

            if (order == null)
            {
                throw new NotFoundException(ApplicationResources.OrderNotFound);
            }

            var result = Mapper.Map<OrderResult>(order);

            return result;
        }

        public async Task<OrderResult> CreateOrderAsync(CreateOrderRequest request)
        {
            if (request == null)
            {
                throw new BadRequestException(ApplicationResources.InvalidRequest);
            }

            var client = await _clientService.GetClientByIdAsync(request.ClientId).ConfigureAwait(continueOnCapturedContext: false);

            if (client == null)
            {
                throw new BadRequestException(ApplicationResources.ClientNotFound);
            }

            var order = Mapper.Map<Order>(request);

            order = await _orderService.CreateOrderAsync(order).ConfigureAwait(continueOnCapturedContext: false);

            var result = Mapper.Map<OrderResult>(order);

            return result;
        }

        public async Task<OrderResult> UpdateOrderAsync(int id, UpdateOrderRequest request)
        {
            if (id <= 0)
            {
                throw new BadRequestException(ApplicationResources.InvalidRequest);
            }

            var order = await _orderService.GetOrderByIdAsync(id).ConfigureAwait(continueOnCapturedContext: false);

            if (order == null)
            {
                throw new NotFoundException(ApplicationResources.OrderNotFound);
            }

            order.ClientId = request.ClientId;
            order.Description = request.Description;
            order.Date = DateTime.Now;

            var result = await _orderService.UpdateOrderAsync(order).ConfigureAwait(continueOnCapturedContext: false);

            return Mapper.Map<OrderResult>(result);
        }

        public async Task DeleteOrderAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException(ApplicationResources.InvalidRequest);
            }

            await _orderService.DeleteOrderAsync(id).ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}