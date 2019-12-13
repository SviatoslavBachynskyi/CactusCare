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
            this.Context = context;
        }

        protected virtual IQueryable<TEntity> ComplexEntities => this.Context.Set<TEntity>().AsNoTracking();

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.ComplexEntities.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.ComplexEntities.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await this.ComplexEntities.FirstOrDefaultAsync(entity => entity.Id.Equals(id));
        }

        public async Task InsertAsync(TEntity entity)
        {
            await Task.Run(() => this.Context.Set<TEntity>().Add(entity));
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => this.Context.Set<TEntity>().Update(entity));
        }

        public async Task DeleteAsync(TKey id)
        {
            var entity = await this.ComplexEntities.FirstOrDefaultAsync(en => en.Id.Equals(id));
            if (entity == null) throw new KeyNotFoundException();

            await Task.Run(() => this.Context.Set<TEntity>().Remove(entity));
        }
    }
}