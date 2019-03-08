using System;
using System.Collections.Generic;
using System.Text;
using TazeBlog.Core.DataAccess.Abstract;
using TazeBlog.Entities.Concrete;

namespace TazeBlog.DataAccess.Abstract
{
    public interface ICategoryDal : IDataAccessBase<Category>
    {
    }
}
