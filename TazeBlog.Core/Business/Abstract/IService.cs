using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TazeBlog.Core.Entities;

namespace TazeBlog.Core.Business.Abstract
{
    public interface IService<T> where T : class, IEntity, new()
    {
        T Add(T entity);
        T Update(T entity);
        int Delete(T entity);
        T GetById(int entityId);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        List<T> GetAll(string filter);
        T Get(string filter);
        T Get(Expression<Func<T, bool>> filter);
        int Count();
    }
}
