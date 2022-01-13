using AutoMapper;
using System;
using pizza.delivery.Application.Services.Interfaces;

namespace pizza.delivery.Application.Services
{
    public abstract class AppServiceBase : IAppServiceBase
    {
        protected IMapper Mapper { get; }

        public AppServiceBase(IMapper mapper)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}