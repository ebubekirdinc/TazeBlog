using System;
using System.Collections.Generic;
using System.Text;
using TazeBlog.Core.Entities;

namespace TazeBlog.Core.DataAccess.Abstract
{
    public interface IDataAccessBase<T> : IEntityRepository<T>
        where T : class, IEntity, new()
    {
    }
}
