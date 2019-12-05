using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CactusCare.Abstractions.Entities;
using CactusCare.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CactusCare.DAL.Repositories
{
    internal abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        protected readonly CactusCareContext Context;

        protected BaseRepository(CactusCareContext context)
        {
            Context = context;
        }

        protected virtual IQueryable<TEntity> ComplexEntities => Context.Set<TEntity>().AsNoTracking();

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await ComplexEntities.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await ComplexEntities.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await ComplexEntities.FirstOrDefaultAsync(entity => entity.Id.Equals(id));
        }

        public async Task InsertAsync(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TKey id)
        {
            var entity = await ComplexEntities.FirstOrDefaultAsync(en => en.Id.Equals(id));
            if (entity == null) throw new KeyNotFoundException();

            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}