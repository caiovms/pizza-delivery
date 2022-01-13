using AutoMapper;
using pizza.delivery.Application.Models.Responses;
using pizza.delivery.Domain.Models;

namespace pizza.delivery.Application.Mappers
{
    public class ClientResultMapper : Profile
    {
        public ClientResultMapper()
        {
            CreateMap<Client, ClientResult>()
                .ForMember(x => x.Id, opts => opts.MapFrom((source, destination, member, context) => source.ClientId))
                .ForMember(x => x.Name, opts => opts.MapFrom((source, destination, member, context) => source.Name))
                .ForMember(x => x.Email, opts => opts.MapFrom((source, destination, member, context) => source.Email))
                .ForMember(x => x.Phone, opts => opts.MapFrom((source, destination, member, context) => source.Phone));
        }
    }
}
