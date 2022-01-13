using pizza.delivery.Domain.Models;
using pizza.delivery.Infrastructure.Data.Repositories;

namespace pizza.delivery.Infrastructure.Data.Interfaces
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
    }
}