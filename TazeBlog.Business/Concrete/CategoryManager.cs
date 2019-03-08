using System;
using System.Collections.Generic;
using System.Text;
using TazeBlog.Business.Abstract;
using TazeBlog.Core.Business.Concrete;
using TazeBlog.DataAccess.Abstract;
using TazeBlog.Entities.Concrete;

namespace TazeBlog.Business.Concrete
{
    public class CategoryManager : ServiceBase<Category>, ICategoryService
    {
        public CategoryManager(ICategoryDal categoryDal) : base(categoryDal)
        {

        }
    }
}
