using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC_GTI.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IList<TEntity> GetAll();
        IList<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Dispose();
        void Delete(TEntity entity);

        void Save(TEntity entity);
    }
}
