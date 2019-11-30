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
        public TEntity GetById(TKey id);

        public IQueryable<TEntity> GetAll();

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        public TEntity Add(TEntity entity);

        public TEntity Update(TEntity entity);

        public void Delete(TKey id);
    }
}
