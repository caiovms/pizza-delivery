using Microsoft.EntityFrameworkCore;
using pizza.delivery.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizza.delivery.Infrastructure.Data
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly PizzaDeliveryDbContext _context;

        public RepositoryBase(PizzaDeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            var entities = await _context.Set<TEntity>().ToListAsync();

            return entities;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id).ConfigureAwait(continueOnCapturedContext: false);

            return entity;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            TEntity entity = await GetByIdAsync(id);

            _context.Set<TEntity>().Remove(entity);

            await _context.SaveChangesAsync();
        }

        public virtual void DetachedLocal(Func<TEntity, bool> entidade)
        {
            var local = _context.Set<TEntity>().Local.Where(entidade).FirstOrDefault();

            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
        }
    }
}