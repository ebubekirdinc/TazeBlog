using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TazeBlog.Core.Entities;

namespace TazeBlog.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Add(T entity);
        T Update(T entity);
        int Delete(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        List<T> GetAll(string filter);
        T GetById(int entityId);
        T Get(string filter);
        T Get(Expression<Func<T, bool>> filter);
        int Count();
    }
}
