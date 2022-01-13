using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pizza.delivery.Infrastructure.Data.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}