using System.Collections.Generic;
using System.Threading.Tasks;

namespace pizza.delivery.Domain.Services.Interfaces
{
    public interface IServiceBase<TEntity>  where TEntity : class
    {
        Task<IList<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(int id);
    }
}