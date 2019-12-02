using CactusCare.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CactusCare.Abstractions.Repositories
{
    public interface IBaseRepository<TEntity, TKey> where TEntity: class, IEntity<TKey>
    { 
        TEntity GetById(TKey id);
        
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TKey id);
    }
}
