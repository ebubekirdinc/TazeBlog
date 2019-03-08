using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TazeBlog.Core.Business.Abstract;
using TazeBlog.Core.DataAccess.Abstract;
using TazeBlog.Core.Entities;

namespace TazeBlog.Core.Business.Concrete
{
    public class ServiceBase<T> : IService<T> where T : class, IEntity, new()
    {
        private IDataAccessBase<T> _dataAccessBase;
        public ServiceBase(IDataAccessBase<T> dataAccessBase)
        {
            _dataAccessBase = dataAccessBase;
        }
        public T Add(T entity)
        {
            return _dataAccessBase.Add(entity);
        }

        public int Delete(T entity)
        {
            return _dataAccessBase.Delete(entity);
        }

        public T GetById(int entityId)
        {
            return _dataAccessBase.GetById(entityId);
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return _dataAccessBase.GetAll(filter);
        }

        public T Update(T entity)
        {
            return _dataAccessBase.Update(entity);
        }

        public virtual T Get(string filter)
        {
            return _dataAccessBase.Get(filter);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _dataAccessBase.Get(filter);
        }

        public List<T> GetAll(string filter)
        {
            return _dataAccessBase.GetAll(filter);
        }

        public int Count()
        {
            return _dataAccessBase.Count();
        }
    }
}
