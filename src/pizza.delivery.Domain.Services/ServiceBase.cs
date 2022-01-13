using pizza.delivery.Domain.Services.Interfaces;
using pizza.delivery.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pizza.delivery.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            return await _repositoryBase.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repositoryBase.GetByIdAsync(id).ConfigureAwait(continueOnCapturedContext: false);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _repositoryBase.CreateAsync(entity);

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await _repositoryBase.UpdateAsync(entity);

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            await _repositoryBase.DeleteAsync(id);
        }
    }
}