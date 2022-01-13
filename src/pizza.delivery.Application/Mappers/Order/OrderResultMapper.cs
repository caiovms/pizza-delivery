using AutoMapper;
using pizza.delivery.Application.Models.Responses;
using pizza.delivery.Domain.Models;

namespace pizza.delivery.Application.Mappers
{
    public class OrderResultMapper : Profile
    {
        public OrderResultMapper()
        {
            CreateMap<Order, OrderResult>()
                .ForMember(x => x.Id, opts => opts.MapFrom((source, destination, member, context) => source.Id))
                .ForMember(x => x.Description, opts => opts.MapFrom((source, destination, member, context) => source.Description))
                .ForMember(x => x.Date, opts => opts.MapFrom((source, destination, member, context) => source.Date))
                .ForMember(x => x.ClientResult, opts => opts.MapFrom((source, destination, member, context) => source.Client));
        }
    }
}