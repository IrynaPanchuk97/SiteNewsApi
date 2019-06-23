using Microsoft.EntityFrameworkCore;
using SiteNewsApi.Models.Entities.Abstract;
using SiteNewsApi.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SiteNewsApi.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
           where TEntity : class, IEntity
    {
        private readonly DbContext _context;
        protected DbSet<TEntity> _entities;
        protected RedisCash redisCash;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
            redisCash = new RedisCash();
        }

        public virtual Task<TEntity> GetByIdAsync(int id)
        {
            var resultCash = redisCash.Get<TEntity>(id.ToString());
            if (resultCash != null) return Task.FromResult(resultCash);

            var result =  ComplexEntities.SingleOrDefaultAsync(t => t.Id == id);
            redisCash.Set(result.Id.ToString(), result);
            return result;
        }

        public virtual Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return ComplexEntities.SingleOrDefaultAsync(predicate);
        }

        public virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            // return Task.FromResult(redisCash.GetAll<TEntity>());
            return Task.FromResult<IEnumerable<TEntity>>(ComplexEntities);
        }

        public virtual Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            
            return Task.FromResult<IEnumerable<TEntity>>(ComplexEntities.Where(predicate));
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
             await Entities.AddAsync(entity);
            _context.SaveChanges();
            redisCash.Set(entity.Id.ToString(), entity);
            return entity ;
        }

        public virtual TEntity Remove(TEntity entity)
        {
            redisCash.Delete(entity.Id.ToString());
            return Entities.Remove(entity).Entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            redisCash.Delete(entity.Id.ToString());
            redisCash.Set(entity.Id.ToString(), entity);
            return Entities.Update(entity).Entity;
        }

        public virtual Task<IEnumerable<TEntity>> GetRangeAsync(uint index, uint amount)
        {
            return Task.FromResult<IEnumerable<TEntity>>(ComplexEntities.Skip((int)index).Take((int)amount));
        }

        public virtual TEntity UpdateWithIgnoreProperty<TProperty>(
            TEntity entity, Expression<Func<TEntity, TProperty>> ignorePropertyExpression)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Entry(entity).Property(ignorePropertyExpression).IsModified = false;
            return entity;
        }

        protected virtual DbSet<TEntity> Entities => _entities ?? (_entities = _context.Set<TEntity>());

        protected virtual IQueryable<TEntity> ComplexEntities => Entities;

    }
}
