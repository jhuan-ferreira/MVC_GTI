using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MVC_GTI.IRepository;
using MVC_GTI.Models;

namespace MVC_GTI.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        public TEntity GetById(int id)
        {
            using (var _context = new DbContext_GTI())
            {
                return _context.Set<TEntity>().Find(id);
            }
        }

        public IList<TEntity> GetAll()
        {
            using (var _context = new DbContext_GTI())
            {
                return _context.Set<TEntity>().Include("Endereco").ToList();
            }
        }

        public IList<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            using (var _context = new DbContext_GTI())
            {
                return _context.Set<TEntity>().Where(predicate).ToList();
            }
        }

        public void Dispose()
        {
            using (var _context = new DbContext_GTI())
            {
                _context.Dispose();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var _context = new DbContext_GTI())
            {
                _context.Entry(entity).State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public void Save(TEntity entity)
        {
            using (var _context = new DbContext_GTI())
            {
                _context.Entry(entity).State = EntityState.Added;

                _context.SaveChanges();
            }
        }
    }
}