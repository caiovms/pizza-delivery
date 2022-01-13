using AutoMapper;
using pizza.delivery.Application.Models.Requests;
using pizza.delivery.Domain.Models;

namespace pizza.delivery.Application.Mappers
{
    public class CreateOrderMapper : Profile
    {
        public CreateOrderMapper()
        {
            CreateMap<CreateOrderRequest, Order>()
               .ForMember(x => x.ClientId, opts => opts.MapFrom((source, destination, member, context) => source.ClientId))
               .ForMember(x => x.Description, opts => opts.MapFrom((source, destination, member, context) => source.Description))
               .ForMember(x => x.Date, opts => opts.MapFrom((source, destination, member, context) => source.Date));
        }
    }
}