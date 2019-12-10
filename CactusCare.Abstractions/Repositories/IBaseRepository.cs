using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CactusCare.Abstractions.Entities;

namespace CactusCare.Abstractions.Repositories
{
    public interface IBaseRepository<TEntity, in TKey> where TEntity : class, IEntity<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetByIdAsync(TKey id);

        Task InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TKey id);
    }
}