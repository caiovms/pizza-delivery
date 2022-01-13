using pizza.delivery.Domain.Models;
using System.Threading.Tasks;

namespace pizza.delivery.Domain.Services.Interfaces
{
    public interface IClientService : IServiceBase<Client>
    {
        Task<Client> GetClientByIdAsync(int id);
    }
}