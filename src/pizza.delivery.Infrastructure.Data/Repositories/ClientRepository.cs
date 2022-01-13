using pizza.delivery.Domain.Models;
using pizza.delivery.Infrastructure.Data.Interfaces;
using System;

namespace pizza.delivery.Infrastructure.Data.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        private readonly PizzaDeliveryDbContext _context;

        public ClientRepository(PizzaDeliveryDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}