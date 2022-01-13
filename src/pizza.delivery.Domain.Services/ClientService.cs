using pizza.delivery.Domain.Models;
using pizza.delivery.Domain.Services.Interfaces;
using pizza.delivery.Infrastructure.Data.Interfaces;
using System;
using System.Threading.Tasks;

namespace pizza.delivery.Domain.Services
{
    public class ClientService : ServiceBase<Client>, IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository) : base(clientRepository)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            var client = await _clientRepository.GetByIdAsync(id).ConfigureAwait(continueOnCapturedContext: false);

            return client;
        }
    }
}