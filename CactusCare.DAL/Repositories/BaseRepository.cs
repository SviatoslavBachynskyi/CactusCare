using CactusCare.Abstractions.Repositories;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CactusCare.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;

namespace CactusCare.DAL.Repositories
{
    internal abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        protected readonly CactusCareContext _context;
        protected virtual IQueryable<TEntity> ComplexEntities { get => _context.Set<TEntity>().AsNoTracking(); }
        public BaseRepository(CactusCareContext context)
        {
            _context = context;
        }
        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public void Delete(TKey id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            _context.Set<TEntity>().Remove(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return ComplexEntities;
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return ComplexEntities.Where(predicate);
        }

        public TEntity GetById(TKey id)
        {
            return ComplexEntities.First(entity => entity.Id.Equals(id));
        }

        public TEntity Update(TEntity entity)
        {
            return _context.Set<TEntity>().Update(entity).Entity;
        }
    }
}
