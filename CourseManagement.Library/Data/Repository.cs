using CourseManagement.Library.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CourseManagement.Library.Data
{
    public abstract class Repository<T, TContext>
        : Repository<T, Guid, TContext>, IRepository<T>
        where T : EntityBase<Guid>
        where TContext : DbContext
    {
        protected Repository(TContext context)
            : base(context)
        {

        }
    }
    public abstract class Repository<T, TKey, TContext>
        : IRepository<T, TKey>
        where T : EntityBase<TKey>
        where TContext : DbContext
    {
        protected TContext _context;
        protected DbSet<T> _dbSet;
        protected Repository(TContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
        public void Delete(TKey entityId)
        {
            var entityToDelete = _dbSet.Find(entityId);
            Delete(entityToDelete);
            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
        public void Edit(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public IQueryable<T> Get()
        {
            return _dbSet.AsQueryable();
        }
        public virtual T Get(TKey entityId)
        {
            return _dbSet.SingleOrDefault(e => e.Id!.Equals(entityId))!;
        }
        public T Get(T entity)
        {
            return _dbSet.SingleOrDefault(e => e.Equals(entity))!;
        }
        public T Get<U>(Expression<Func<T, bool>> predicate, Expression<Func<T, U>>? includePredicate = null)
        {
            var set = _dbSet.AsQueryable();
            if (includePredicate != null)
            {
                set = set.Include(includePredicate);
            }
            return set.SingleOrDefault(predicate)!;
            
        }

        public IQueryable<T> GetMultiple(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}
